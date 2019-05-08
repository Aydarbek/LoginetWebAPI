using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public class Album
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(32)]
        public string AlbumName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

    }
}
