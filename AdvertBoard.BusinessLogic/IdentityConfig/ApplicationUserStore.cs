using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertBoard.DbAccess;
using AdvertBoard.DbAccess.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdvertBoard.BusinessLogic.IdentityConfig
{
    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(AdvertBoardContext context)
            : base(context)
        {
        }
    }
}
