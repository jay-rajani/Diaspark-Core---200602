using System;
using System.Collections.Generic;

namespace Diaspark.Models
{
    public partial class faartrpaymentdtl
    {
        public string trans_bk { get; set; }
        public string trans_no { get; set; }
        public string serial_no { get; set; }
        public DateTime trans_dt { get; set; }
        public string apply_flag { get; set; }
        public string voucher_no { get; set; }
        public string inv_no { get; set; }
        public DateTime? inv_dt { get; set; }
        public decimal? original_amt { get; set; }
        public decimal? balance_amt { get; set; }
        public decimal? apply_amt { get; set; }
        public decimal? disctaken_amt { get; set; }
        public string company_id { get; set; }
        public string user_cd { get; set; }
        public DateTime? update_dt { get; set; }
        public string update_flag { get; set; }
        public DateTime? due_dt { get; set; }
        public DateTime? voucher_dt { get; set; }
        public string apply_to { get; set; }
        public string gl_account { get; set; }
        public string ref_no { get; set; }
        public decimal? disctaken_amt1 { get; set; }
        public string gl_account1 { get; set; }
        public decimal? disctaken_amt2 { get; set; }
        public string gl_account2 { get; set; }
    }
}
