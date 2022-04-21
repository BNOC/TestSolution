namespace Test.Api.Entities
{
    public class Box
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int ShedId { get; set; }

        public Shed Shed { get; set; }
        
        public ICollection<Thing> Things { get; set; }
    }
}
