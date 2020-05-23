using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diaspark.Models;
using Microsoft.EntityFrameworkCore;


namespace Diaspark.Manager
{
    public class SaoiInventoryPosting 
    {
		private MainEntities db;

		public SaoiInventoryPosting(MainEntities db1)
		{
			db = db1;
		}


		public int Post(saoitrinvhd saoitrinvhd)
		{

			insert_invntrtransdtl(saoitrinvhd);
			insert_invntrtranshd(saoitrinvhd);

			
			return 200;
		}

		public int insert_invntrtranshd(saoitrinvhd saoitrinvhd)
		{
			String ls_memo_flag, ls_ri_flag = "";


			invntrtranshd existing_inventory = db.invntrtranshds.Find(saoitrinvhd.trans_bk, saoitrinvhd.trans_no, saoitrinvhd.trans_dt, saoitrinvhd.company_id);

			if (existing_inventory != null)
			{
				db.Entry(existing_inventory).State = EntityState.Deleted;
			}


			diintrtranshd existing_diaminventory = db.diintrtranshds.Find(saoitrinvhd.trans_bk, saoitrinvhd.trans_no, saoitrinvhd.trans_dt, saoitrinvhd.company_id);

			if (existing_diaminventory != null)
			{
				db.Entry(existing_diaminventory).State = EntityState.Deleted;
			}

			ls_memo_flag = "N";
			switch (saoitrinvhd.trans_type)
			{
				case "I":
					ls_ri_flag = "T";
					break;
				case "M":
					ls_memo_flag = "Y";
					ls_ri_flag = "I";
					break;
				case "C":
					ls_ri_flag = "R";
					break;
				case "R":
					ls_memo_flag = "Y";
					ls_ri_flag = "R";
					break;
				default:
					//
					break;
			}

			if ((saoitrinvhd.details.Where(p => p.item_flag != "D" && p.item_flag != "T")).Count() > 0)
			{
				invntrtranshd invntrtranshd = new invntrtranshd();

				invntrtranshd.trans_bk = saoitrinvhd.trans_bk;
				invntrtranshd.trans_no = saoitrinvhd.trans_no;
				invntrtranshd.trans_dt = saoitrinvhd.trans_dt;
				invntrtranshd.ref_id = saoitrinvhd.account_id;
				invntrtranshd.ref_no = saoitrinvhd.po_no;
				invntrtranshd.ref_dt = saoitrinvhd.po_dt;
				invntrtranshd.trans_type = "CUST";
				invntrtranshd.location = "";
				invntrtranshd.account_period = saoitrinvhd.trans_period;
				invntrtranshd.ri_flag = ls_ri_flag;
				invntrtranshd.remarks = "";
				invntrtranshd.user_cd = saoitrinvhd.user_cd;
				invntrtranshd.company_id = saoitrinvhd.company_id;
				invntrtranshd.update_dt = saoitrinvhd.update_dt;
				invntrtranshd.update_flag = "V";
				invntrtranshd.trans_flag = saoitrinvhd.trans_flag;
				invntrtranshd.action_flag = "A";
				invntrtranshd.post_flag = "U";
				invntrtranshd.memo_flag = ls_memo_flag;



				db.invntrtranshds.Add(invntrtranshd);

			}

			if ((saoitrinvhd.details.Where(p => p.item_flag == "D")).Count() == 0)
			{
				return 0;
			}

			diintrtranshd diintrtranshd = new diintrtranshd();


			diintrtranshd.trans_bk = saoitrinvhd.trans_bk;
			diintrtranshd.trans_no = saoitrinvhd.trans_no;
			diintrtranshd.trans_dt = saoitrinvhd.trans_dt;
			diintrtranshd.ref_id = saoitrinvhd.account_id;
			diintrtranshd.ref_no = saoitrinvhd.po_no;
			diintrtranshd.ref_dt = saoitrinvhd.po_dt;
			diintrtranshd.trans_type = "CUST";
			diintrtranshd.location = "";
			diintrtranshd.account_period = saoitrinvhd.trans_period;
			diintrtranshd.ri_flag = ls_ri_flag;
			diintrtranshd.remarks = "";
			diintrtranshd.user_cd = saoitrinvhd.user_cd;
			diintrtranshd.company_id = saoitrinvhd.company_id;
			diintrtranshd.update_dt = saoitrinvhd.update_dt;
			diintrtranshd.update_flag = "V";
			diintrtranshd.trans_flag = saoitrinvhd.trans_flag;
			diintrtranshd.action_flag = "A";
			diintrtranshd.post_flag = "U";
			diintrtranshd.memo_flag = ls_memo_flag;

			db.diintrtranshds.Add(diintrtranshd);
			return 0;
		}


		public int insert_invntrtransdtl(saoitrinvhd saoitrinvhd)
		{

			Decimal ldec_rec_pcs = 0, ldec_rec_wt = 0, ldec_iss_pcs = 0, ldec_iss_wt = 0, ldec_rec_amt = 0, ldec_price = 0;
			Decimal ldec_rec_price = 0, ldec_iss_amt = 0, ldec_iss_price = 0;
			DateTime dt = new DateTime(1955, 01, 01);
			String ls_rec_unit = "", ls_iss_unit = "", ls_ri_flag = "", ls_memo_flag;
			String ls_serial_no, ls_ref_serial_no, ls_ref_type, ls_item_id;

			db.Database.ExecuteSqlCommand("delete from invntrtransdtl where trans_no = '" + saoitrinvhd.trans_no + "' And trans_bk = '" + saoitrinvhd.trans_bk + "'");
			db.Database.ExecuteSqlCommand("delete from diintrtransdtl where trans_no = '" + saoitrinvhd.trans_no + "' And trans_bk = '" + saoitrinvhd.trans_bk + "'");


			foreach (var ll_currentrow in saoitrinvhd.details)
			{

				ls_item_id = ll_currentrow.item_id;
				if (ls_item_id == null)
				{
					ls_item_id = "NA";
				}

				ldec_price = ll_currentrow.item_price ?? 0;

				if (ll_currentrow.trans_qty != 0)
				{
					ldec_price = ll_currentrow.net_amt ?? 0 / ll_currentrow.trans_qty ?? 0;
				}

				if (saoitrinvhd.trans_type == "C" || saoitrinvhd.trans_type == "R") // receipt
				{
					ldec_rec_pcs = ll_currentrow.trans_qty_pc ?? 0;
					ldec_rec_wt = ll_currentrow.trans_qty_wt ?? 0;
					ldec_iss_pcs = 0;
					ldec_iss_wt = 0;
					ls_rec_unit = ll_currentrow.sell_unit;
					ls_iss_unit = "";
					ldec_rec_amt = ll_currentrow.net_amt ?? 0;
					ldec_iss_amt = 0;
					ldec_rec_price = ldec_price;
					ldec_iss_price = 0;
					ls_ri_flag = "R";
				}

				else if (saoitrinvhd.trans_type == "I" || saoitrinvhd.trans_type == "M") // issue
				{
					ldec_iss_pcs = ll_currentrow.trans_qty_pc ?? 0;
					ldec_iss_wt = ll_currentrow.trans_qty_wt ?? 0;
					ldec_rec_pcs = 0;
					ldec_rec_wt = 0;
					ls_iss_unit = ll_currentrow.sell_unit;
					ls_rec_unit = "";
					ldec_iss_amt = ll_currentrow.net_amt ?? 0;
					ldec_rec_amt = 0;
					ldec_iss_price = ldec_price;
					ldec_rec_price = 0;
					ls_ri_flag = "I";
				}

				// for -ve memo return: no posting into inventory
				if ((saoitrinvhd.trans_type == "R") && (ldec_rec_wt < 0 || ldec_rec_pcs < 0) && ll_currentrow.item_flag == "D")
				{
					continue;
				}

				if ((saoitrinvhd.trans_type == "M") || (saoitrinvhd.trans_type == "R"))
				{
					ls_memo_flag = "Y";
				}
				else
				{
					ls_memo_flag = "N";
				}

				ls_serial_no = ll_currentrow.serial_no + "A";

				if (ll_currentrow.item_flag == "D" || ll_currentrow.item_flag == "T")
				{

					db.diintrtransdtls.Add(setdiintrtransdtl());
				}
				else
				{
					db.invntrtransdtls.Add(setinvntrtransdtl());

				}

				ls_serial_no = ll_currentrow.serial_no + "B";
				// price diff
				if ((saoitrinvhd.trans_type == "C") && (saoitrinvhd.trans_for_flag == "PD"))
				{
					ldec_iss_pcs = ldec_rec_pcs;
					ldec_iss_wt = ldec_rec_wt;
					ls_iss_unit = ls_rec_unit;
					ldec_iss_amt = 0;
					ldec_iss_price = 0;

					ldec_rec_pcs = 0;
					ldec_rec_wt = 0;
					ls_rec_unit = "";
					ldec_rec_amt = 0;
					ldec_rec_price = 0;


					if (ll_currentrow.item_flag == "D" || ll_currentrow.item_flag == "T")
					{

						db.diintrtransdtls.Add(setdiintrtransdtl());
					}
					else
					{
						db.invntrtransdtls.Add(setinvntrtransdtl());

					}



				}

				// the invoice is against a memo so do memo receipt and invoice issue.
				else if ((saoitrinvhd.trans_type == "I") && (ll_currentrow.ref_type == "M") &&
						  (ll_currentrow.ref_no != null)) // the invoice is against a memo so do memo receipt and invoice issue.
				{

					ls_memo_flag = "Y";
					ldec_rec_pcs = ldec_iss_pcs;
					ldec_rec_wt = ldec_iss_wt;
					ls_rec_unit = ls_iss_unit ?? "";
					ls_rec_unit = ls_iss_unit ?? "";
					ldec_rec_amt = ldec_iss_amt;

					//var data = db.saoitrinvdtls.SqlQuery("select * " +
					//								   "from saoitrinvdtl " +
					//								   "where company_id = @company_id " +
					//								   "and trans_bk = 'SM01' "+
					//								   "and trans_no = @ls_ref_no " +
					//								   "and trans_dt = @ldt_ref_dt " +
					//								   "and serial_no = @ref_serial_no ",
					//								   new SqlParameter("@company_id", ll_currentrow.company_id),
					//								   new SqlParameter("@ls_ref_no", ll_currentrow.ref_no??""),
					//								   new SqlParameter("@ldt_ref_dt", ll_currentrow.ref_dt?),
					//								   new SqlParameter("@ref_serial_no", ll_currentrow.ref_serial_no??"")
					//								   ).FirstOrDefault();

					var data = db.saoitrinvdtls.Where(dtl =>
						dtl.company_id == ll_currentrow.company_id
						&& dtl.trans_bk == "SM01"
						&& dtl.trans_no == ll_currentrow.ref_no
						&& dtl.trans_dt == ll_currentrow.ref_dt
						&& dtl.serial_no == ll_currentrow.ref_serial_no
					).FirstOrDefault();

					if (data == null)
					{
						continue;
					}
					//net_amt, trans_qty into :ldec_rec_price, :ldec_trans_qty1
					if (data.trans_qty > 0)
					{
						ldec_rec_price = data.net_amt ?? 0 / data.trans_qty ?? 0;
					}

					if ((ls_rec_unit != "") && ((ls_rec_unit.ToUpper().Substring(0, 3) == "C") || (ls_rec_unit.ToUpper().Substring(0, 3) == "W")))
					{
						ldec_rec_amt = ldec_rec_price * ldec_rec_wt;
					}
					else
					{
						ldec_rec_amt = data.net_amt ?? 0 * ldec_rec_pcs;
					}

					ldec_iss_pcs = 0;
					ldec_iss_wt = 0;
					ls_iss_unit = "";
					ldec_iss_amt = 0;
					ldec_iss_price = 0;


					if (ll_currentrow.item_flag == "D" || ll_currentrow.item_flag == "T")
					{

						db.diintrtransdtls.Add(setdiintrtransdtl());
					}
					else
					{
						db.invntrtransdtls.Add(setinvntrtransdtl());

					}

				}

				invntrtransdtl setinvntrtransdtl()
				{
					invntrtransdtl dtl = new invntrtransdtl();

					dtl.trans_bk = ll_currentrow.trans_bk;
					dtl.trans_no = ll_currentrow.trans_no;
					dtl.trans_dt = ll_currentrow.trans_dt;
					dtl.serial_no = ls_serial_no;
					dtl.item_type = ll_currentrow.item_flag;
					dtl.item_id = ls_item_id;
					dtl.rec_pcs = ldec_rec_pcs;
					dtl.rec_wt = ldec_rec_wt;
					dtl.iss_pcs = ldec_iss_pcs;
					dtl.iss_wt = ldec_iss_wt;
					dtl.rec_unit = ls_rec_unit;
					dtl.iss_unit = ls_iss_unit;
					dtl.rec_amt = ldec_rec_amt;
					dtl.iss_amt = ldec_iss_amt;
					dtl.user_cd = ll_currentrow.user_cd;
					dtl.company_id = ll_currentrow.company_id;
					dtl.update_dt = DateTime.Now; ;
					dtl.update_flag = "V";
					dtl.trans_flag = "A";
					dtl.action_flag = saoitrinvhd.trans_type;
					dtl.post_flag = "U";
					dtl.item_category = ll_currentrow.item_category;
					dtl.memo_flag = ls_memo_flag;
					dtl.packet_no = ll_currentrow.packet_no;
					dtl.rec_price = ldec_rec_price;
					dtl.iss_price = ldec_iss_price;
					dtl.location = ll_currentrow.location;
					dtl.item_cost = ll_currentrow.item_cost;
					dtl.account_period = saoitrinvhd.trans_period;
					dtl.ri_flag = ls_ri_flag;
					dtl.stone_type = "";
					dtl.stone_shape = "";
					dtl.stone_qlty = "";
					dtl.size = ll_currentrow.size;
					dtl.prod_so_type = ll_currentrow.prod_so_type;

					return dtl;
				}

				diintrtransdtl setdiintrtransdtl()
				{
					;
					diintrtransdtl dtl = new diintrtransdtl();

					dtl.trans_bk = ll_currentrow.trans_bk;
					dtl.trans_no = ll_currentrow.trans_no;
					dtl.trans_dt = ll_currentrow.trans_dt;
					dtl.serial_no = ls_serial_no;
					dtl.item_type = ll_currentrow.item_flag;
					dtl.item_id = ls_item_id;
					dtl.rec_pcs = ldec_rec_pcs;
					dtl.rec_wt = ldec_rec_wt;
					dtl.iss_pcs = ldec_iss_pcs;
					dtl.iss_wt = ldec_iss_wt;
					dtl.rec_unit = ls_rec_unit;
					dtl.iss_unit = ls_iss_unit;
					dtl.rec_amt = ldec_rec_amt;
					dtl.iss_amt = ldec_iss_amt;
					dtl.user_cd = ll_currentrow.user_cd;
					dtl.company_id = ll_currentrow.company_id;
					dtl.update_dt = DateTime.Now; ;
					dtl.update_flag = "V";
					dtl.trans_flag = "A";
					dtl.action_flag = saoitrinvhd.trans_type;
					dtl.post_flag = "U";
					dtl.item_category = ll_currentrow.item_category;
					dtl.memo_flag = ls_memo_flag;
					dtl.packet_no = ll_currentrow.packet_no;
					dtl.rec_price = ldec_rec_price;
					dtl.iss_price = ldec_iss_price;
					dtl.location = ll_currentrow.location;
					dtl.item_cost = ll_currentrow.item_cost;
					dtl.account_period = saoitrinvhd.trans_period;
					dtl.ri_flag = ls_ri_flag;
					dtl.stone_type = "";
					dtl.stone_shape = "";
					dtl.stone_qlty = "";
					dtl.size = ll_currentrow.size;
					dtl.prod_so_type = ll_currentrow.prod_so_type;

					return dtl;

				}
			}


			return 0;
		}

	}
}
