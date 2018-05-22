using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities.Entities;
using Library.DAL.Identity;
using Library.DAL.Interfaces;
using Library.BLL.Interfaces;
using Library.BLL.DTO;
using Library.BLL.Infrastructure;
using Microsoft.AspNet.Identity;
using Library.DAL.Repositories;

namespace Library.BLL.Servises
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
