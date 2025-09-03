using System;

namespace TestMillion.Entities.POCOs
{
    public class Owner : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
