using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthleticWebApp.DataAccess.Entities
{
    public class Athlete
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public double Height { get; set; }
        public double Weigth { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Gender { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public List<Competition> Competitions { get; set; }

    }
}
