namespace Artisanal.Web.ViewComponentClasses;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

public class AuthVC : ViewComponent{

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var name = User.Identity.Name;
        var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "visitor";
        
        return View("Default","hhh");
    }
}