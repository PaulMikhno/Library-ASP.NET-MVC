using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL;
using Library.Entities.Entities;
using Library.DAL.Identity;
using Library.DAL.Interfaces;
using Library.BLL.Interfaces;
using Library.BLL.DTO;
using Library.BLL.Infrastructure;
using Microsoft.AspNet.Identity;
using System.Security.Claims;


namespace Library.BLL.Servises
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);

            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() > 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }

               
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);


               
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Registration successful", "");
            }
            
                return new OperationDetails(false, "User with such login already exists", "Email");
            
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;

           
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);


            if (user != null)
            {
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                   DefaultAuthenticationTypes.ApplicationCookie);
            } 

            return claim;
        }

       
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);

                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
      
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
