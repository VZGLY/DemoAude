using DemoAude___Domain;
using DemoAude___Domain.ViewModel;

namespace DemoAude___DAL.Interfaces;

public interface IUserRepository
{

    bool UserAlreadyExist(string email);

    User GetOneByEmail(string Email);

    bool AddUser(UserRegisterViewModel userRegisterViewModel);

}