namespace TestMillion.Entities.POCOs
{
    public class PropertyImage : Entity
    {
        public string File { get; set; }
        public bool Enabled { get; set; }
        public int? PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
