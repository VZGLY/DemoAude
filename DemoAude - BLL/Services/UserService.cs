using DemoAude___BLL.Interfaces;
using DemoAude___DAL.Interfaces;
using DemoAude___Domain;
using DemoAude___Domain.ViewModel;

namespace DemoAude___BLL.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;


    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public bool RegisterUser(UserRegisterViewModel userRegisterViewModel)
    {
        if (_userRepository.UserAlreadyExist(userRegisterViewModel.Email))
        {
            return false;
        }

        return _userRepository.AddUser(userRegisterViewModel);


    }

    public User? LoginUser(UserLoginViewModel userLoginViewModel)
    {
        if (_userRepository.UserAlreadyExist(userLoginViewModel.Email))
        {
            User user = _userRepository.GetOneByEmail(userLoginViewModel.Email);

            if (user.Password == userLoginViewModel.Password)
            {
                return user;
            }
        }
        return null;
    }
}