using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diaspark.Models;

namespace Diaspark
{
    public class GenericFunction
    {
        private MainEntities db = new MainEntities();

        public sysmmsmodulelink gf_get_module_online(string as_from, String as_to)
        {
            var data = db.sysmmsmodulelinks.Where(d => d.from_module_id == as_from && d.to_module_id == as_to).FirstOrDefault(); ;
            
            return data;
        }
    }
}
