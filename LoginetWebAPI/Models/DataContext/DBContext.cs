﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoginetWebAPI.Models
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }

    }
}
