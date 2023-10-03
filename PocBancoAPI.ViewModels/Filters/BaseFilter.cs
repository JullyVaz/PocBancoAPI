using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocBancoAPI.ViewModels.Filters
{
    public class BaseFilter
    {
        public int pageSize { get; set; } = 3;
        public int pageNumber { get; set; } = 1;

        [JsonIgnore]
        public int skip
        {
            get
            {
                return (pageNumber - 1) * pageSize;
            }

            set { }
        }
    }
}
