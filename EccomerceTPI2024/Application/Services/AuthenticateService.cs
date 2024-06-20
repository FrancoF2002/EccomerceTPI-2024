using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthenticateService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User? ValidateUser(AuthenticateRequest authenticateRequest) 
        {
            if (string.IsNullOrEmpty(authenticateRequest.Name) || string.IsNullOrEmpty(authenticateRequest.Password))
            {
                return null;
            }

            var user = _userRepository.GetByName(authenticateRequest.Name);

            if (authenticateRequest.Name == user.Name && authenticateRequest.Password == user.Password)
            {
                return user;
            }

            return null;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest user)
        {
            var userToAuth = ValidateUser(user);

            if (userToAuth == null)
            { 
                throw new ApplicationException("El usuario no pudo ser autenticado");
            }



        }
    }
}
