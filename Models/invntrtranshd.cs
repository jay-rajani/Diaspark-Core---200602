using System;
using System.Collections.Generic;

namespace Diaspark.Models
{
    public partial class invntrtranshd
    {
        public string trans_bk { get; set; }
        public string trans_no { get; set; }
        public DateTime trans_dt { get; set; }
        public string ref_id { get; set; }
        public string ref_no { get; set; }
        public DateTime? ref_dt { get; set; }
        public string trans_type { get; set; }
        public string rec_location { get; set; }
        public string location { get; set; }
        public string account_period { get; set; }
        public string ri_flag { get; set; }
        public string remarks { get; set; }
        public string user_cd { get; set; }
        public string company_id { get; set; }
        public DateTime? update_dt { get; set; }
        public string update_flag { get; set; }
        public string trans_flag { get; set; }
        public string action_flag { get; set; }
        public string post_flag { get; set; }
        public string memo_flag { get; set; }
        public string packet_no { get; set; }
        public string wb_bk { get; set; }
        public string wb_no { get; set; }
        public DateTime? wb_dt { get; set; }
        public string style_no { get; set; }
        public decimal? qty_filled { get; set; }
        public string wip_posted_flag { get; set; }
    }
}
