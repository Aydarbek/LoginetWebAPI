using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string AlbumName { get; set; }

        public string Description { get; set; }
    }
}
