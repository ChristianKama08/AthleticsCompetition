using System.ComponentModel.DataAnnotations;

namespace AthleticWebApp.DataAccess.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Athlete> Athletes { get; set; }

    }
}
