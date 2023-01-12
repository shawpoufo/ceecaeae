namespace Artisanal.Web.Controllers;

using Artisanal.Web.Models;
using Artisanal.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class AuthController : Controller{

    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {   
        _authService = authService;
    }

    [HttpGet("Login")]
    public IActionResult Login(string? ReturnUrl){
        ViewBag.ReturnUrl = ReturnUrl;
        return View();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginViewModel model,string? ReturnUrl){
        if(!ModelState.IsValid)
            return View(model);

        ResponseDto responseDto = await _authService.Login(model.UserName,model.PassWord);
        if(responseDto.IsSuccess)
            HttpContext.Response.Headers.Add("Set-Cookie",responseDto.Result as string);
        else
        {
            ViewBag.BadCredentials = "Bad Credentials";
            ViewBag.ReturnUrl = ReturnUrl;
            return View(model);
        }

        if (Url.IsLocalUrl(ReturnUrl))
            return Redirect(ReturnUrl);
        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> LogOut(){
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index","Home");
    }

}