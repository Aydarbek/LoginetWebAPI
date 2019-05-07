using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string Account { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set; }

        [Required]        
        [StringLength(32)]
        public string FirstName { get; set; }

        [StringLength(32)]
        public string LastName { get; set; }

        [StringLength(32)]
        public string Occupation { get; set; }

    }
}
