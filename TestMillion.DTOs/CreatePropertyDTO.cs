namespace TestMillion.DTOs
{
    public class CreatePropertyDTO
    {
        public int OwnerId { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public decimal Price { get; init; }
        public string CodeInternal { get; init; }
        public int Year { get; init; }
    }
}
