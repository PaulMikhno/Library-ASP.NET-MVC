using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Identity;
using Library.DAL.Interfaces;
using Library.Entities.Entities;
using Library.Entities.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.DAL.Identity
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        IUnitOfWork Database { get; set; }

        public AppDbInitializer(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        protected async override void Seed(ApplicationContext context)
        {
          
               var user = new ApplicationUser { Email = "admin@mail.com", UserName = "admin@mail.com" };
                var result = await Database.UserManager.CreateAsync(user,"qwerty");
            
                await Database.UserManager.AddToRoleAsync(user.Id,nameof(IdentityRoles.Admin));
           

                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = "Sunny st.", Name = "Admin" };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
             
            base.Seed(context);
        }
    }
}
