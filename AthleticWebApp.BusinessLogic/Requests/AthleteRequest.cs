using System.ComponentModel.DataAnnotations;

namespace AthleticWebApp.BusinessLogic.Requests
{
    public class AthleteRequest
    {
        //[Required(ErrorMessage = "This field is required")]
        //[MinLength(10)]
        //[MaxLength(50)]
        public string FullName {  get; set; }
        //[Required]
        //[Range(0.5, 2.5, ErrorMessage = "Please enter a valid height in meters.")]
        public double Height { get; set; }
        //[Required]
        //[Range(1, 500, ErrorMessage = "Please enter a valid weight in kilograms.")]
        public double Weigth { get; set; }
        public DateTime DateOfBirthday { get; set; }

        //[Required(ErrorMessage = "The gender is required, M for Male and F for Female")]
        public string Gender { get; set; }
        public int CountryId{ get; set; }
        public  int TeamId{ get; set; }
    }
}
