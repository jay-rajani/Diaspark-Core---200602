﻿using System;
using System.Collections.Generic;

namespace Diaspark.Models
{
    public partial class saoitrinvhd
    {
        public string company_id { get; set; }
        public string trans_bk { get; set; }
        public string trans_no { get; set; }
        public DateTime trans_dt { get; set; }
        public string trans_type { get; set; }
        public string action_flag { get; set; }
        public string trans_flag { get; set; }
        public string post_flag { get; set; }
        public string terms { get; set; }
        public string account_id { get; set; }
        public string ship_id { get; set; }
        public string trans_period { get; set; }
        public string ship_via { get; set; }
        public string ship_terms { get; set; }
        public decimal? ship_per { get; set; }
        public decimal? ship_amt { get; set; }
        public string insurance_terms { get; set; }
        public decimal? insurance_per { get; set; }
        public decimal? insurance_amt { get; set; }
        public string tax_terms { get; set; }
        public decimal? tax_per { get; set; }
        public decimal? tax_amt { get; set; }
        public string discount_terms { get; set; }
        public decimal? discount_per { get; set; }
        public decimal? discount_amt { get; set; }
        public decimal? item_amt { get; set; }
        public decimal? other_amt { get; set; }
        public decimal? net_amt { get; set; }
        public string sales_person { get; set; }
        public decimal? salescomm_per { get; set; }
        public decimal? salescomm_amt { get; set; }
        public string ref_no { get; set; }
        public DateTime? ref_dt { get; set; }
        public string remarks { get; set; }
        public string user_cd { get; set; }
        public DateTime? update_dt { get; set; }
        public string update_flag { get; set; }
        public string tracking_no { get; set; }
        public string message_id { get; set; }
        public string doc_type { get; set; }
        public string doc_no { get; set; }
        public string price_level { get; set; }
        public string inv_print_no { get; set; }
        public string po_no { get; set; }
        public DateTime? po_dt { get; set; }
        public string adv_type { get; set; }
        public string adv_check_no { get; set; }
        public DateTime? adv_check_dt { get; set; }
        public decimal? adv_amt { get; set; }
        public decimal? balance_due_amt { get; set; }
        public DateTime? ship_dt { get; set; }
        public decimal? credit_limit_amt { get; set; }
        public decimal? credit_exceeded_amt { get; set; }
        public string ship_nm { get; set; }
        public string ship_contact_nm { get; set; }
        public string ship_address1 { get; set; }
        public string ship_address2 { get; set; }
        public string ship_city { get; set; }
        public string ship_state { get; set; }
        public string ship_zip { get; set; }
        public string ship_country { get; set; }
        public string ship_phone1 { get; set; }
        public string ship_fax1 { get; set; }
        public string cust_type1 { get; set; }
        public string cust_type2 { get; set; }
        public DateTime? due_dt { get; set; }
        public decimal? trans_qty_pc { get; set; }
        public decimal? trans_qty_wt { get; set; }
        public DateTime? sale_dt { get; set; }
        public string authorisation_no { get; set; }
        public string bank_id { get; set; }
        public string trans_for_flag { get; set; }
        public decimal? gold_price { get; set; }
        public DateTime? gold_price_dt { get; set; }
        public string location { get; set; }
        public string pl_bk { get; set; }
        public string pl_no { get; set; }
        public DateTime? pl_dt { get; set; }
        public DateTime? order_dttime { get; set; }
        public string old_id { get; set; }
        public string wip_posted_flag { get; set; }
        public string master_po_no { get; set; }
        public decimal? ac_percent1 { get; set; }
        public decimal? ac_amount1 { get; set; }
        public decimal? ac_percent2 { get; set; }
        public decimal? ac_amount2 { get; set; }
        public decimal? ac_percent3 { get; set; }
        public decimal? ac_amount3 { get; set; }
        public decimal? ac_percent4 { get; set; }
        public decimal? ac_amount4 { get; set; }
        public string dc_id { get; set; }
        public string dc_trfr_flag { get; set; }
        public string price_update { get; set; }
        public DateTime? price_update_dt { get; set; }
        public string price_update_by { get; set; }
        public decimal? silver_price { get; set; }
        public decimal? platinum_price { get; set; }
        public decimal? palladium_price { get; set; }
        public IList<saoitrinvdtl> details { get; set; }
    }
}
