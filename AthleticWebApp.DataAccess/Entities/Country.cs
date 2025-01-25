namespace AthleticWebApp.DataAccess.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Athlete> Athletes { get; set; }
    }
}
