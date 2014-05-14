using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FilterProductFeature
    {
        public int FilterId { get; set; }
        public string FilterName { get; set; }
        public List<string> FilterValues { get; set; }
    }
}
