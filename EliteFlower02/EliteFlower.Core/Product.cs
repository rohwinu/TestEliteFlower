using System;
using System.Collections.Generic;

#nullable disable

namespace EliteFlower.Core
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string PathImage { get; set; }
        public int Manufacture { get; set; }
    }
}
