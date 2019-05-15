using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public interface IDataContext
    {
        IEnumerable<User> Users { get; }
        IEnumerable<Album> Albums { get; }
    }
}
