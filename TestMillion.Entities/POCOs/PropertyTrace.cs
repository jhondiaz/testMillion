using System;

namespace TestMillion.Entities.POCOs
{
    public class PropertyTrace : Entity
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? Tax { get; set; }
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
