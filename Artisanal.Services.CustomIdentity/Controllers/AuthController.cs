using Artisanal.Services.CustomIdentity.DbContexts;
using Artisanal.Services.CustomIdentity.Models;
using Artisanal.Services.CustomIdentity.Models.DAO;
using Artisanal.Services.CustomIdentity.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Artisanal.Services.CustomIdentity.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController:ControllerBase{

    private ApplicationDbContext _dbContext;
    private LoginRepository _repository;
    private PasswordHasher<LoginDAO> _hasher;

    public AuthController(ApplicationDbContext context , PasswordHasher<LoginDAO> hasher,LoginRepository repository)
    {
        _dbContext=context;
        _hasher = hasher;
        _repository = repository;
    }

    public string SignUp(){
        
        return "Hi";
    }

    [HttpPost("Login")]
    public  async Task<IActionResult> Login([FromBody]LoginModel loginModel){
        var usr = await _repository.Find(loginModel.UserName,loginModel.Password);
        
        if(usr == null)
            return NotFound();

        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier,Convert.ToString(usr.Id)),
            new Claim(ClaimTypes.Name,usr.UserName),
            new Claim(ClaimTypes.Role,usr.Role.Label)
        };
        // var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
        var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

        var ClaimsPrincipal = new ClaimsPrincipal(claimIdentity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,ClaimsPrincipal);
        
        return Ok(HttpContext.Response.Cookies);
    }

}