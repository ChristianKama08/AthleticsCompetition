using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthleticWebApp.DataAccess.Entities
{
	public class Result
	{
		[Key]
		public int Id { get; set; }
		//Score in other words
		public string MeasurementType { get; set; }

		[ForeignKey(nameof(Competition))]
		public int CompetitionId { get; set; }
		public Competition? Competition { get; set; }

	}
}