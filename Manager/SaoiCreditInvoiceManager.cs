using Diaspark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Diaspark.Manager
{
    public class SaoiCreditInvoiceManager
    {
        MainEntities db = new MainEntities();
        GenericFunction GenericFunctionClass = new GenericFunction();

        public SaoiCreditInvoiceManager()
        {

            SaoiInventoryPosting = new SaoiInventoryPosting(db);
        }

        SaoiInventoryPosting SaoiInventoryPosting;

        int li_ret = 200;
        public int CreateCreditInvoice(saoitrinvhd data)
        {
            if (validate_new_Invoice(data))
            {
                return 500;
            }

            db.saoitrinvhds.Add(data);
            foreach (var ll_currentrow in data.details)
            {
                db.saoitrinvdtls.Add(ll_currentrow);
            }

            if (PostInvoice(data) != 200)
            {
                return 500;
            }


            return Saverecords();
        }

        public int UpdateCreditInvoice(string trans_no, string trans_bk, string company_id, saoitrinvhd data)
        {

            if (validate_Existing_Invoice(trans_no, trans_bk, company_id, data))
            {
                return 500;
            }


            db.Entry(data).State = EntityState.Modified;

            var old_records = db.saoitrinvdtls.Where(d => d.trans_no == trans_no && d.trans_bk == trans_bk);
            foreach (var ll_currentrow in data.details)
            {
                if (old_records.Any(d => d.serial_no == ll_currentrow.serial_no))
                    db.Entry(ll_currentrow).State = EntityState.Modified;
                else
                    db.saoitrinvdtls.Add(ll_currentrow);
            }

            foreach (var ll_currentrow in old_records)
            {
                if (!data.details.Any(d => d.serial_no == ll_currentrow.serial_no))
                    db.saoitrinvdtls.Remove(ll_currentrow);
            }

            //SalesPostingManager.post(saoitrinvhd);

            return Saverecords();
        }


        public bool validate_new_Invoice(saoitrinvhd data)
        {
            if (check_existing_invoice(data))
            {
                return true;
            }

            return false;

        }

        public bool validate_Existing_Invoice(string trans_no, string trans_bk, string company_id, saoitrinvhd data)
        {
            if (check_existing_invoice(data))
            {
                return false;
            }

            if (trans_no != data.trans_no && trans_bk != data.trans_bk && company_id != data.company_id)
            {
                return true;
            }

            return false;

        }

        public bool check_existing_invoice(saoitrinvhd data)
        {
            var existing_records = db.saoitrinvhds.Where(d => d.trans_no == data.trans_no && d.trans_bk == data.trans_bk);
            //db.saoitrinvhds.Find(data.company_id, data.trans_bk, data.trans_no, data.trans_dt);

            if (existing_records.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public int PostInvoice(saoitrinvhd data)
        {

            var ls_invn_online = GenericFunctionClass.gf_get_module_online("SAOI", "INVN");

            if (ls_invn_online.online == "Y")
            {
                li_ret = SaoiInventoryPosting.Post(data);
            }

            return li_ret;
        }


        public int Saverecords()
        {
            try
            {
                db.SaveChanges();
            }


            catch (DbUpdateException)
            {
                return 500;
            }

            return 200;
        }

    }
}
