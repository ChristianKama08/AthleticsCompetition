namespace AthleticWebApp.BusinessLogic.Profiles.DTOs
{
	public class AthleteDto
	{
		public int Id { get; set; }
		public string FullName {  get; set; }
		public double Height { get; set; }
		public double Weigth { get; set; }
		public DateTime DateOfBirthday { get; set; }
		public string Gender { get; set; }
		public int CountryId { get; set; }
		public string CountryName { get; set; }

		public int TeamId { get; set; }
		public string TeamName { get; set; }
	}
}
