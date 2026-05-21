using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantPicturesOfSpidermanMauiApp.DTO
{
    public class PictureDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileLocation { get; set; }
        public List<CategoryDTO> Categories { get; set; } = [];

    }
}
