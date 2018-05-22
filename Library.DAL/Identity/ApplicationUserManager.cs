using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Entities.Entities;
namespace Library.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {

        }
    }

}
