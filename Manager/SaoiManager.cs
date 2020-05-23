using Diaspark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Diaspark.Manager
{
    public class SaoiManager
    {
        MainEntities db = new MainEntities();
        SaoiInvoiceManager SaoiInvoiceManager;
        SaoiCreditInvoiceManager SaoiCreditInvoiceManager;

        public SaoiManager()
        {

            SaoiInvoiceManager = new SaoiInvoiceManager();
            SaoiCreditInvoiceManager = new SaoiCreditInvoiceManager();
        }
        public IQueryable<saoitrinvhd> GetAllInvoices()
        {
            return db.saoitrinvhds;
        }

        public saoitrinvhd GetInvoice(string trans_no, String trans_bk, string dtl_type)
        {

            saoitrinvhd data = db.saoitrinvhds.SingleOrDefault(m => m.trans_no == trans_no && m.trans_bk == trans_bk);

            if (dtl_type == "Y")
            {
                data.details = db.saoitrinvdtls.Where(d => d.trans_no == trans_no && d.trans_bk == trans_bk).ToList();
            }

            return data;

        }

        public int Create(saoitrinvhd data)
        {
            int li_ret = 0;
            switch (data.trans_bk)
            {
                case "SI01":
                    li_ret = SaoiInvoiceManager.CreateInvoice(data);
                    break;
                case "SC01":
                    li_ret = SaoiCreditInvoiceManager.CreateCreditInvoice(data);
                    break;
                case "SM01":
                    //                    
                    break;
                case "SO01":
                    //
                    break;
                default:
                    //
                    break;
            }
            return li_ret;
        }

        public int Update(string trans_no, string trans_bk, string company_id, saoitrinvhd data)
        {
            int li_ret = 0;
            switch (data.trans_bk)
            {
                case "SI01":
                    li_ret = SaoiInvoiceManager.UpdateInvoice(trans_no, trans_bk, company_id, data);
                    break;
                case "SC01":
                    li_ret = SaoiCreditInvoiceManager.UpdateCreditInvoice(trans_no, trans_bk, company_id, data);
                    break;
                case "SM01":
                    //                    
                    break;
                case "SO01":
                    //
                    break;
                default:
                    //
                    break;
            }
            return li_ret;
        }



    }
}
