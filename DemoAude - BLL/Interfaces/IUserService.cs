using DemoAude___Domain;
using DemoAude___Domain.ViewModel;

namespace DemoAude___BLL.Interfaces;

public interface IUserService
{
    bool RegisterUser(UserRegisterViewModel userRegisterViewModel);

    User? LoginUser(UserLoginViewModel userLoginViewModel);

}