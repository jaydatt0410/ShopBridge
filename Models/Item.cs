using System;
using System.Collections.Generic;

#nullable disable

namespace Practical_Test_Jaydatt.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? InsertedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
