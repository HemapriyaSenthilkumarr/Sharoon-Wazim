using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDetails.Models
{

    //•	Inside the "EmpDetails" class, we can define the properties that we want to include in our model.
    //These properties should represent the data we want to store in the database.
    public class EmpDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped] 
        // This property will not be mapped to the database
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public string Gender { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }


}

   