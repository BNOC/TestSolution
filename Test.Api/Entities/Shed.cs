namespace Test.Api.Entities
{
    public class Shed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Box> Boxes { get; set; }
    }
}
