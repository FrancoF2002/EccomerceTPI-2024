using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository 
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public User? GetByName(string name)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.Name == name);
        } 

        public int AddUser(User user)
        {
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
            return user.Id;
        }

    }
}
