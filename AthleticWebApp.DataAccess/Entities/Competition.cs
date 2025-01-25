using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthleticWebApp.DataAccess.Entities
{
    public class Competition
    {
        //[Key]
        public int Id { get; set; }
        public string CompetitionName { get; set; }

        //[ForeignKey(nameof(Athlete))]
        public int AthleteId { get; set; }
        public Athlete Athlete { get; set; }

        public List<Result>? Results { get; set; }

    }
}
