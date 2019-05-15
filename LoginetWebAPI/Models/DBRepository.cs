using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public class DBRepository : IDataContext
    {
        DBContext _context;

        public DBRepository (DBContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Users
        {
            get { return _context.Users; }
        } 

        public IEnumerable<Album> Albums
        {
            get { return _context.Albums; }
        }
    }
}
