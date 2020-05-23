using System;
using System.Collections.Generic;

namespace Diaspark.Models
{
    public partial class faartrinvhd
    {
        public string trans_bk { get; set; }
        public string trans_no { get; set; }
        public DateTime trans_dt { get; set; }
        public string trans_period { get; set; }
        public string trans_flag { get; set; }
        public string post_flag { get; set; }
        public string trans_typ { get; set; }
        public string inv_no { get; set; }
        public DateTime? inv_dt { get; set; }
        public string account_id { get; set; }
        public decimal inv_amt { get; set; }
        public DateTime? due_dt { get; set; }
        public string terms { get; set; }
        public decimal? disc_per { get; set; }
        public decimal? disc_amt { get; set; }
        public DateTime? disc_dt { get; set; }
        public decimal? paid_amt { get; set; }
        public decimal? disctaken_amt { get; set; }
        public decimal? balance_amt { get; set; }
        public string description { get; set; }
        public string company_id { get; set; }
        public string user_cd { get; set; }
        public DateTime? update_dt { get; set; }
        public string update_flag { get; set; }
        public string action_flag { get; set; }
        public string inv_type { get; set; }
        public string sales_person { get; set; }
        public DateTime? sale_dt { get; set; }
        public string clear_flag { get; set; }
        public decimal? clear_amt { get; set; }
        public decimal? item_qty { get; set; }
        public string comments { get; set; }
        public string soldto_id { get; set; }
        public string old_id { get; set; }
        public string parent_id { get; set; }
        public DateTime? interest_dt { get; set; }
        public int? invoice_rating { get; set; }
        public string approval_flag { get; set; }
        public DateTime? approval_date { get; set; }
        public string approval_user_cd { get; set; }
        public string ref_trans_no { get; set; }
        public string qb_flag { get; set; }
        public DateTime? qb_date { get; set; }
    }
}
