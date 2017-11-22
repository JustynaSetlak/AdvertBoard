using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess
{
    public class AdvertBoardContext : DbContext
    {
        protected AdvertBoardContext()
            : base("name=AdvertBoardContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public DbSet<Advert> Adverts { get; set; }
    }
}
