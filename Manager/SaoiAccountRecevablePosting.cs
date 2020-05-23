using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diaspark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diaspark.Manager
{
    public class SaoiAccountRecevablePosting
    {
        private MainEntities db;
		int li_ret = 200;

        public SaoiAccountRecevablePosting(MainEntities db1)
        {
            db = db1;
        }
		
		public int post(saoitrinvhd data)
		{
			li_ret = post_dtl(data);
			
			if (li_ret != 200)
			{
				return li_ret;
			}

			li_ret = Post_hd(data);

			return li_ret;
		}

		public int  Post_hd(saoitrinvhd data)
		{	
			string[] trans_group;
			int li_noofentries = 0, li_pay1_days = 1;
			string ls_trans_no1, ls_inv_type, ls_ref_no2;
			decimal ldec_pay1_per = 100, ldec_per = 1, li_days = 1, ldec_net_amt1 = 0, ldec_net_amt2 = 0;


			if (data.trans_type == "I")
			{
				



				trans_group = new string[12] { data.trans_no + "a", data.trans_no + "b", data.trans_no + "c",
										   data.trans_no + "d", data.trans_no + "e", data.trans_no + "f",
										   data.trans_no + "g", data.trans_no + "h", data.trans_no + "i",
										   data.trans_no + "j", data.trans_no + "k", data.trans_no + "l"
										 };

				var existing_records = db.faartrinvhds.Where(c => trans_group.Contains(c.trans_no)).ToList();

				foreach (var ll_currentrow in existing_records)
				{
					db.Entry(ll_currentrow).State = EntityState.Deleted;
				}

				//db.database.ExecuteSqlComm&&("delete from faartrinvhd where trans_no in (a,b,c)");

				saoimsterms saoimsterms = db.saoimstermses.Where(d => d.id == data.terms).FirstOrDefault();

				if (data.terms == null)
				{
					li_noofentries = 1;
					ldec_pay1_per = 100;
					//li_pay1_days = daysafter(date(ldt_trans_dt), date(ldt_due_dt))

				}
				else
				{

					if (saoimsterms.pay1_per > 0)
						li_noofentries = 1;

					if (saoimsterms.pay2_per > 0)
						li_noofentries = 2;

					if (saoimsterms.pay3_per > 0)
						li_noofentries = 3;

					if (saoimsterms.pay4_per > 0)
						li_noofentries = 4;

					if (saoimsterms.pay5_per > 0)
						li_noofentries = 5;

					if (saoimsterms.pay6_per > 0)
						li_noofentries = 6;

					if (saoimsterms.pay7_per > 0)
						li_noofentries = 7;

					if (saoimsterms.pay8_per > 0)
						li_noofentries = 8;

					if (saoimsterms.pay9_per > 0)
						li_noofentries = 9;

					if (saoimsterms.pay10_per > 0)
						li_noofentries = 10;

					if (saoimsterms.pay11_per > 0)
						li_noofentries = 11;

					if (saoimsterms.pay12_per > 0)
						li_noofentries = 12;

					if (saoimsterms.pay1_per + saoimsterms.pay2_per + saoimsterms.pay3_per + saoimsterms.pay4_per +
						saoimsterms.pay5_per + saoimsterms.pay6_per + saoimsterms.pay7_per + saoimsterms.pay8_per +
						saoimsterms.pay9_per + saoimsterms.pay10_per + saoimsterms.pay11_per + saoimsterms.pay12_per
						!= 100
						)
					{
						return 500;
					}
				}


				if ((li_noofentries == 3) && (saoimsterms.pay1_per >= 33.33m) && (saoimsterms.pay1_per <= 33.34m) &&
					 (saoimsterms.pay2_per >= 33.33m) && (saoimsterms.pay2_per <= 33.34m) &&
					 (saoimsterms.pay3_per >= 33.33m) && (saoimsterms.pay3_per <= 33.34m))
				{
					saoimsterms.pay1_per = 3;
					saoimsterms.pay2_per = 3;
					saoimsterms.pay3_per = 3;

				}





				if (li_noofentries == 6 && saoimsterms.pay1_per >= 16.60m && saoimsterms.pay1_per <= 16.70m &&
					saoimsterms.pay2_per >= 16.60m && saoimsterms.pay2_per <= 16.70m && saoimsterms.pay3_per >= 16.60m &&
					saoimsterms.pay3_per <= 16.70m && saoimsterms.pay4_per >= 16.60m && saoimsterms.pay4_per <= 16.70m &&
					saoimsterms.pay5_per >= 16.60m && saoimsterms.pay5_per <= 16.70m && saoimsterms.pay6_per >= 16.60m &&
					saoimsterms.pay6_per <= 16.70m
					)
				{
					saoimsterms.pay1_per = 6;
					saoimsterms.pay2_per = 6;
					saoimsterms.pay3_per = 6;
					saoimsterms.pay4_per = 6;
					saoimsterms.pay5_per = 6;
					saoimsterms.pay6_per = 6;

				}

				for (int i = 0; i < li_noofentries; i++)

				{
					switch (i)
					{
						case 1:
							ldec_per = saoimsterms.pay1_per ?? 0;
							li_days = li_pay1_days;
							if (li_noofentries > 1)
							{
								ls_trans_no1 = data.trans_no.Trim() + "a";
							}
							else
							{
								ls_trans_no1 = data.trans_no;
							}
							data.due_dt = saoimsterms.pay1_date;
							break;
						case 2:
							ldec_per = saoimsterms.pay2_per ?? 0;
							li_days = saoimsterms.pay2_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "b";
							data.due_dt = saoimsterms.pay2_date;
							break;
						case 3:
							ldec_per = saoimsterms.pay3_per ?? 0;
							li_days = saoimsterms.pay3_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "c";
							data.due_dt = saoimsterms.pay3_date;
							break;
						case 4:
							ldec_per = saoimsterms.pay4_per ?? 0;
							li_days = saoimsterms.pay4_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "d";
							data.due_dt = saoimsterms.pay4_date;

							break;
						case 5:
							ldec_per = saoimsterms.pay5_per ?? 0;
							li_days = saoimsterms.pay5_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "e";
							data.due_dt = saoimsterms.pay5_date;
							break;

						case 6:
							ldec_per = saoimsterms.pay6_per ?? 0;
							li_days = saoimsterms.pay6_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "f";
							data.due_dt = saoimsterms.pay6_date;

							break;
						case 7:
							ldec_per = saoimsterms.pay7_per ?? 0;
							li_days = saoimsterms.pay7_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "g";
							data.due_dt = saoimsterms.pay6_date;

							break;
						case 8:
							ldec_per = saoimsterms.pay8_per ?? 0;
							li_days = saoimsterms.pay8_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "h";
							data.due_dt = saoimsterms.pay6_date;
							break;
						case 9:
							ldec_per = saoimsterms.pay9_per ?? 0;
							li_days = saoimsterms.pay9_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "i";
							data.due_dt = saoimsterms.pay6_date;
							break;
						case 10:
							ldec_per = saoimsterms.pay10_per ?? 0;
							li_days = saoimsterms.pay10_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "j";
							data.due_dt = saoimsterms.pay6_date;


							break;
						case 11:
							ldec_per = saoimsterms.pay11_per ?? 0;
							li_days = saoimsterms.pay11_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "k";
							data.due_dt = saoimsterms.pay6_date;
							break;
						case 12:
							ldec_per = saoimsterms.pay12_per ?? 0;
							li_days = saoimsterms.pay12_days ?? 0;
							ls_trans_no1 = data.trans_no.Trim() + "l";
							data.due_dt = saoimsterms.pay6_date;
							break;

						default:
							//
							break;
					}

					if (saoimsterms.disc_days == null)
					{
						saoimsterms.disc_days = 0;
					}

					if (li_days > 0)
					{
						//p data.due_dt = 
					}

					if (data.due_dt < data.sale_dt)
					{
						li_ret = 500;
						continue;
					}


					if (i == li_noofentries)
					{
						ldec_net_amt1 = data.net_amt??0 - ldec_net_amt2;
					}


					else
					{
						if (ldec_per == 3m || ldec_per == 6m)
						{
							ldec_net_amt1 = data.net_amt??0 / ldec_per;
							ldec_net_amt2 += ldec_net_amt1;
						}
						else
						{
							ldec_net_amt1 = data.net_amt??0 * (ldec_per / 100);
							ldec_net_amt2 += ldec_net_amt1;
						}
					}

					ls_inv_type = data.details[1].ref_type;

					if (ls_inv_type == "O")
					{
						ls_ref_no2 = data.details[1].ref_no;
					}

					var trans_fflag = db.saoitrinvhds.Where(d => d.trans_bk == "SO01").Select(x => new
										{
											x.trans_for_flag
										}
										).FirstOrDefault();

					ls_inv_type = trans_fflag.trans_for_flag;

					if (ls_inv_type == null)
						ls_inv_type = "I";
				//select trans_for_flag into: ls_inv_type
				//from saoitrinvhd
				//where trans_bk = 'SO01' and trans_no = :ls_ref_no2;
				//end if

				}

			}

			if (li_ret == 500)
				return 500;

				return 200;
			}
			









			public int post_dtl(saoitrinvhd data)
        {
			decimal ldec_price, ldec_net_amt1, ldec_apply_amt;
			if (data.trans_type == "I")
			{
				
			   db.Database.ExecuteSqlCommand("delete from faartrinvdtl where trans_no = '" + data.trans_no + "' && trans_bk = '" + data.trans_bk + "'");
				
			}

			if (data.trans_type == "C")
			{
				post_undo_fa(data);
			}

			db.Database.ExecuteSqlCommand("delete from faartrpaymentdtl where trans_no = '" + data.trans_no + "' && trans_bk = '" + data.trans_bk + "'");

			if (data.trans_type == "C")
			{
				foreach (var ll_currentrow in data.details)
				{
					ldec_price = ll_currentrow.item_price ?? 0;

					if (ll_currentrow.trans_qty != 0)
					{
						ldec_price = ll_currentrow.net_amt ?? 0 / ll_currentrow.trans_qty ?? 0;
					}

					ldec_net_amt1 = ll_currentrow.item_amt??0;
					if (ldec_net_amt1 <= 0 || ldec_net_amt1 == null || ll_currentrow.ref_no == null)
					{
						//Continue	
					}
					else
					{
			
						
						var temp = db.faartrinvhds.Where(d => d.trans_bk == "1234" && d.trans_no == ll_currentrow.ref_no).FirstOrDefault(); ;
						if (temp.balance_amt > 0)
						{
							if (ldec_net_amt1 > temp.balance_amt)
							{
								ldec_apply_amt = temp.balance_amt??0;

							}
							else
							{
								ldec_apply_amt = ldec_net_amt1;

								faartrinvhd faartrinvhd_1 = db.faartrinvhds.Where(d => d.trans_bk == "1234" && d.trans_no == ll_currentrow.ref_no).FirstOrDefault(); ;

								if (faartrinvhd_1 != null)
								{
									faartrinvhd_1.action_flag = "0";
									faartrinvhd_1.paid_amt = faartrinvhd_1.paid_amt + ldec_apply_amt;
									faartrinvhd_1.balance_amt = faartrinvhd_1.balance_amt - ldec_apply_amt;
									db.Entry(faartrinvhd_1).State = EntityState.Modified;
								}

								saoitrinvhd saoitrinvhd_1 = db.saoitrinvhds.Where(d => d.trans_bk == "1234" && d.trans_no == ll_currentrow.ref_no).FirstOrDefault(); ;

								if (saoitrinvhd_1 != null)
								{
									saoitrinvhd_1.update_flag = "V";
									db.saoitrinvhds.Add(saoitrinvhd_1);

								}


								faartrpaymentdtl faartrpaymentdtl_1 = new faartrpaymentdtl();
								faartrpaymentdtl_1.trans_bk = ll_currentrow.trans_bk;
								faartrpaymentdtl_1.trans_no = ll_currentrow.trans_no;
								faartrpaymentdtl_1.serial_no = "100";
								faartrpaymentdtl_1.trans_dt = ll_currentrow.trans_dt;
								faartrpaymentdtl_1.apply_flag = "N";
								faartrpaymentdtl_1.voucher_no = "1234" + ll_currentrow.ref_no;
								faartrpaymentdtl_1.inv_no = "1234" + ll_currentrow.ref_no; ;
								faartrpaymentdtl_1.inv_dt = ll_currentrow.ref_dt;
								faartrpaymentdtl_1.original_amt = temp.inv_amt;
								faartrpaymentdtl_1.balance_amt = temp.balance_amt;
								faartrpaymentdtl_1.apply_amt = ldec_apply_amt;
								faartrpaymentdtl_1.disctaken_amt = 0;
								faartrpaymentdtl_1.company_id = ll_currentrow.company_id;
								faartrpaymentdtl_1.user_cd = ll_currentrow.user_cd;
								faartrpaymentdtl_1.update_dt = DateTime.Now;
								faartrpaymentdtl_1.update_flag = "V";
								faartrpaymentdtl_1.voucher_dt = ll_currentrow.ref_dt;
								faartrpaymentdtl_1.due_dt = temp.due_dt;

								db.faartrpaymentdtls.Add(faartrpaymentdtl_1);

							}
						}


					}
				}
				
					
			}
			return 200;
		}

		public void post_undo_fa(saoitrinvhd saoitrinvhd)
		{

			var data = db.faartrpaymentdtls.Where(d => d.trans_bk == saoitrinvhd.trans_bk && d.trans_no == saoitrinvhd.trans_no).ToList(); ;
			String ls_trans_no, ls_trans_bk;

			foreach (var ll_currentrow in data)
			{
				ls_trans_no = ll_currentrow.voucher_no.Substring(0, 4);
				ls_trans_bk = ll_currentrow.voucher_no.Substring(5, 11);

				faartrinvhd faartrinvhd = db.faartrinvhds.Where(d => d.trans_bk == saoitrinvhd.trans_bk && d.trans_no == saoitrinvhd.trans_no).FirstOrDefault(); ;

				if (faartrinvhd != null)
				{
					faartrinvhd.action_flag = "0";
					faartrinvhd.paid_amt = faartrinvhd.paid_amt - ll_currentrow.apply_amt;
					faartrinvhd.disctaken_amt = faartrinvhd.disctaken_amt - ll_currentrow.disctaken_amt;
					faartrinvhd.balance_amt = faartrinvhd.inv_amt - (faartrinvhd.paid_amt + faartrinvhd.disctaken_amt) + (ll_currentrow.apply_amt + ll_currentrow.disctaken_amt);
					db.Entry(faartrinvhd).State = EntityState.Modified;
				}

			}
			
		}
	}
}
