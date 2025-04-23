using Data.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using presentation.mvc.Models;
using presentation.mvc.Models.AccountViewModel;
using presentation.mvc.Utilities;

namespace presentation.mvc.Controllers;

public class AccountController(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> singInManager) : Controller
{
    //login
    //register
    //logout
    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(RegisterViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        var user = new AppUser()
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            UserName = viewModel.UserName,
            Email = viewModel.Email,
        };
        var res = userManager.CreateAsync(user, viewModel.Password).Result;
        if (res.Succeeded)
            return RedirectToAction("Login");
        foreach (var error in res.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        var user = userManager.FindByEmailAsync(viewModel.Email).Result;
        if (user is not null)
        {
            bool flag = userManager.CheckPasswordAsync(user, viewModel.Password).Result;
            if (flag)
            {
                var res = singInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false)
                    .Result;
                if (res.IsNotAllowed)
                    ModelState.AddModelError(string.Empty, "user is not allowed");
                if (res.IsLockedOut)
                    ModelState.AddModelError(string.Empty, "user is locked out");
                if (res.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "user not found");
            ;
        }

        return View(viewModel);
    }



    #region password

    [HttpGet]
    public IActionResult ForgetPassword() => View();

    [HttpPost]
    public IActionResult SendResetPasswordLink(ForgetPasswordViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = userManager.FindByEmailAsync(viewModel.Email).Result;
            if (user is not null)
            {
                var token = userManager.GeneratePasswordResetTokenAsync(user).Result;
                var resetPasswordLink = Url.Action("ResetPassword", "Account", new { email = viewModel.Email, token },
                    Request.Scheme);
                var email = new Email()
                {
                    To = viewModel.Email,
                    Subject = "Reset Password",
                    Body = resetPasswordLink,
                };
                EmailSettings.SendEmail(email);
                return RedirectToAction("CheckYourInbox");
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid Operation");

        return View(nameof(ForgetPassword), viewModel);
    }

    #endregion

    public IActionResult CheckYourInbox() => View();

    [HttpGet]
    public IActionResult ResetPassword(string email, string token)
    {
        TempData["email"] = email;
        TempData["token"] = token;
        return View();
    }

    [HttpPost]
    public IActionResult ResetPassword(ResetPasswordViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        string email = TempData["email"].ToString() ?? string.Empty;
        string token = TempData["token"].ToString() ?? string.Empty;
        var user = userManager.FindByEmailAsync(email).Result;
        if (user is not null)
        {
            var res = userManager.ResetPasswordAsync(user, token, viewModel.Password).Result;
            if(res.Succeeded)
                return RedirectToAction("Login");
            foreach (var error in res.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(nameof(ResetPassword), viewModel);
    }
}