using crypto_app.DAL.Context;
using crypto_app.Helpers.DTOs.Account;
using crypto_app.Helpers.Enums;
using crypto_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace crypto_app.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if (!ModelState.IsValid)
        {
            return View(registerDto);
        }

        AppUser user = new AppUser()
        {
            UserName = registerDto.Name,
            Name = registerDto.Name,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }

        return Redirect("Login");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto, string? ReturnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        AppUser user = await _userManager.FindByEmailAsync(loginDto.EmailOrUsername)
            ?? await _userManager.FindByNameAsync(loginDto.EmailOrUsername);

        if (user == null)
        {
            ModelState.AddModelError("", "Email or Username yanlisdir");
            return View();
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);

        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "Birazdan yeniden sinayin");
            return View();
        }

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Email or Username ve ya Password yanlisdir");
            return View();
        }

        if (ReturnUrl != null)
        {
            return Redirect(ReturnUrl);
        }

        return RedirectToAction("Index", "Home");

    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> CreateRole()
    {
        foreach (var item in Enum.GetValues(typeof(UserRoles)))
        {
            if (!await _roleManager.RoleExistsAsync(item.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
            }
        }

        return RedirectToAction("Index", "Home");
    }

}
