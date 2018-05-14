using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Entities.Models;
namespace Library.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("LibraryContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
