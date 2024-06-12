using Application.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;


namespace Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
       public User GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public int AddUser(UserForAddRequest request) 
        {
            var obj = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                UserType = request.UserType,
            };
            return _repository.AddUser(obj);
        }
    }
}
