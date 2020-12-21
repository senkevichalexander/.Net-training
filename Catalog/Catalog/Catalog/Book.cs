using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catalog
{
    public class Book
    {
        [RegularExpression("^[-,0-9]+$", ErrorMessage = "Number should be in 0 to 9 range")]
        [ISBNFormat("XXX-X-XX-XXXXXX-X", "XXXXXXXXXXXXX", ErrorMessage = "Format is wrong")]
        public string ISBN { get; set; }

        [StringLength(1000, ErrorMessage = "Book name should be less than or equal to 200 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Book name should have one character at least")]
        public string BookName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public List<Author> Authors { get; set; }
    }
}
