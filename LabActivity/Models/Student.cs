using System.ComponentModel.DataAnnotations;

namespace LabActivity.Models
{
    public enum Course
    {
        BSIT, BSCS, BSIS, OTHER
    }

    public class Student
    {

        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Display(Name = "GPA")]
        [Required(ErrorMessage = "GPA Selection is Required.")]
        public double? GPA { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course is Required.")]
        public Course Course { get; set; }

        [Display(Name = "Admission Date")]
        [Required(ErrorMessage = "Date Selection is Required.")]
        [DataType(DataType.Date)]
        public DateTime? AdmissionDate { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{4}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Follow the Format 0000-000-0000")]
        public string PhoneNumber { get; set; }

    }
}
