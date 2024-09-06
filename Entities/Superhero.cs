





namespace SuperHero2.Entities
{
    public class Superhero
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public string FirstName  { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string place {  get; set; } = string.Empty;
    }
}
