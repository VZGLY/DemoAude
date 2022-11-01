using DemoAude___BLL.Interfaces;
using DemoAude___Domain;
using DemoAude___Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoAude.Controllers;

public class UserController : Controller
{

    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    // GET
    public IActionResult Register()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Register(UserRegisterViewModel userRegisterViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _userService.RegisterUser(userRegisterViewModel);

        return RedirectToAction("Index", "Home");
    }


    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserLoginViewModel userLoginViewModel)
    {
        
        
        if (!ModelState.IsValid)
        {
            return View();
        }

        User user = _userService.LoginUser(userLoginViewModel);

        if (user == null)
        {
            return View();
        }
        
        HttpContext.Session.SetString("Email", user.Email);

        return RedirectToAction("Index", "Home");

    }

    public IActionResult Disconnect()
    {
        HttpContext.Session.Clear();
        
        return RedirectToAction("Index", "Home");
    }


}