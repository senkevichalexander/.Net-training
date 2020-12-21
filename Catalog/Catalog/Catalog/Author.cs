using System.ComponentModel.DataAnnotations;

namespace Catalog
{
    public class Author
    {
        [StringLength(200, ErrorMessage = "Authors first name should be less than or equal to 200 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Authors first name should have one character at least")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FirstName { get; set; }

        [StringLength(200, ErrorMessage = "Authors last name should be less than or equal to 200 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Authors last name should have one character at least")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LastName { get; set; }
    }
}
