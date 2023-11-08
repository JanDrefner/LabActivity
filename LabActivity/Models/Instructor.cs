using System.ComponentModel.DataAnnotations;

namespace LabActivity.Models
{
    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor
    }
    public class Instructor
    {
        
        public int Id { get; set; }
        
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your First Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your Last Name.")]
        public string LastName { get; set; }

        [Display(Name = "Is Tenured")]
        [Required(ErrorMessage = "IsTenured is Required")]
        public bool IsTenured { get; set; }

        [Display(Name = "Academic Rank")]
        [Required(ErrorMessage = "Academic Rank is Required.")]
        public Rank InstructorRank { get; set; }

        [Display(Name = "Hiring Date")]
        [Required(ErrorMessage = "Hiring Date is Required.")]
        [DataType(DataType.Date)]
        public DateTime? HiringDate { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{4}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the Format 000-000-0000")]
        [Required(ErrorMessage = "Phone Number is Required.")]
        public string? PhoneNumber { get; set; }


    }
}
