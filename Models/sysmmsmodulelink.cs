using System;
using System.Collections.Generic;

namespace Diaspark.Models
{
    public partial class sysmmsmodulelink
    {
        public string from_module_id { get; set; }
        public string to_module_id { get; set; }
        public string link { get; set; }
        public string company_id { get; set; }
        public string user_cd { get; set; }
        public string update_flag { get; set; }
        public DateTime? update_dt { get; set; }
        public string trans_flag { get; set; }
        public string online { get; set; }
    }
}
