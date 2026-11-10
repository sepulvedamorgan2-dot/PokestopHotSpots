using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokestopHotSpots.Models;
using PokestopHotSpots.ViewModels;

namespace PokestopHotSpots.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel form)
    {
        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var user = new AppUser { UserName = form.Email, Email = form.Email, TrainerName = form.TrainerName, FriendshipCode = form.FriendshipCode };
        var result = await _userManager.CreateAsync(user, form.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(form);
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Login(string? returnUrl = null)
{
    ViewData["ReturnUrl"] = returnUrl;
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(LoginViewModel form, string? returnUrl = null)
{
    ViewData["ReturnUrl"] = returnUrl;
    if (!ModelState.IsValid)
    {
        return View(form);
    }

    var result = await _signInManager.PasswordSignInAsync(
        form.Email, form.Password, form.RememberMe, lockoutOnFailure: false);

    if (!result.Succeeded)
    {
        ModelState.AddModelError("", "That email and password don't match an account.");
        return View(form);
    }

    return LocalRedirect(returnUrl ?? "/");
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Logout()
{
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
}
}