using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertBoard.DbAccess.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdvertBoard.DbAccess
{
    public class AdvertBoardContext : IdentityDbContext<User>
    {
        public AdvertBoardContext()
            : base("name=AdvertBoardContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Advert> Adverts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
