using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman.Domain
{
    public class Picture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileLocation { get; set; }
        public List<Category> Categories { get; set; } = [];
    }
}
