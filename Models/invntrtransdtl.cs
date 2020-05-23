using System;
using System.Collections.Generic;

namespace Diaspark.Models
{
    public partial class invntrtransdtl
    {
        public string trans_bk { get; set; }
        public string trans_no { get; set; }
        public DateTime trans_dt { get; set; }
        public string serial_no { get; set; }
        public string stone_type { get; set; }
        public string stone_qlty { get; set; }
        public string stone_shape { get; set; }
        public string stone_size { get; set; }
        public string item_type { get; set; }
        public string item_id { get; set; }
        public decimal? rec_pcs { get; set; }
        public decimal? rec_wt { get; set; }
        public decimal? iss_pcs { get; set; }
        public decimal? iss_wt { get; set; }
        public string rec_unit { get; set; }
        public string iss_unit { get; set; }
        public decimal? rec_amt { get; set; }
        public decimal? iss_amt { get; set; }
        public string user_cd { get; set; }
        public string company_id { get; set; }
        public DateTime? update_dt { get; set; }
        public string update_flag { get; set; }
        public string trans_flag { get; set; }
        public string action_flag { get; set; }
        public string post_flag { get; set; }
        public string item_category { get; set; }
        public string memo_flag { get; set; }
        public string packet_no { get; set; }
        public decimal? rec_price { get; set; }
        public decimal? iss_price { get; set; }
        public string location { get; set; }
        public string account_period { get; set; }
        public string ri_flag { get; set; }
        public decimal? clear_qty { get; set; }
        public decimal? open_pcs { get; set; }
        public decimal? stock_pcs { get; set; }
        public string style_bagno { get; set; }
        public decimal? size { get; set; }
        public string metal_type { get; set; }
        public string color { get; set; }
        public string diamond_qlty { get; set; }
        public string ref_bk { get; set; }
        public string ref_no { get; set; }
        public DateTime? ref_dt { get; set; }
        public string ref_serial_no { get; set; }
        public string barcode_flag { get; set; }
        public string barcode_no { get; set; }
        public string style_no { get; set; }
        public string comments { get; set; }
        public string old_item_id { get; set; }
        public string wb_bk { get; set; }
        public string wb_no { get; set; }
        public DateTime? wb_dt { get; set; }
        public string wb_serial_no { get; set; }
        public string old_item_category { get; set; }
        public string prod_so_type { get; set; }
        public decimal? item_cost { get; set; }
        public string stage_id { get; set; }
    }
}
