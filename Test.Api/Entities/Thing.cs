namespace Test.Api.Entities
{
    public class Thing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BoxId { get; set; }

        public Box Box { get; set; }
    }
}
