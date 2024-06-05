using Domain.Entities;
using System;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        User? GetByName(string name);
        int AddUser(UserForAddRequest request);
    }
}
