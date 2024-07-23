using Application.Models.Request;
using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IUserService 
    {
        User? GetByName(string name);
        int AddUser(UserForAddRequest user);
    }
}
