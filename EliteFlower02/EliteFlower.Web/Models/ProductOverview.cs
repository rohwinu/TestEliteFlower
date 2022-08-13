using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EliteFlower.Web.Models
{
    public class ProductOverview
    {
        public ProductOverview()
        {
            Manufactures = new List<ManufactureOverview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string PathImage { get; set; }
        public int Manufacture { get; set; }
        public string ManufactureName { get; set; }
        public List<ManufactureOverview> Manufactures { get; set; }
    }
}
