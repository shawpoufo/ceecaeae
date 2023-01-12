using Artisanal.Services.CustomIdentity.DbContexts;
using Artisanal.Services.CustomIdentity.Models.DAO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Artisanal.Services.CustomIdentity.Repositories;

public class LoginRepository {
    private ApplicationDbContext _dbContext;
    private PwdHash _hasher;

    public LoginRepository(ApplicationDbContext applicationDbContext , PwdHash hasher) 
    {
        _dbContext = applicationDbContext;
        _hasher = hasher;
    }

    public Task<LoginDAO?> Find(string userName , string password)
    {
        var h = _hasher.ComputeHash(password);

        return _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => 
            u.UserName == userName && 
            u.HashedPassword == h
            );
    }

    public async Task<LoginDAO> Create(string username , string password ){
        var user = await Find(username,password);
        
        if(user != null)
            throw new AlreadyAvailableCredentials("Another user alread has those credentials");
        
        var newUser = await _dbContext.Users.AddAsync(new LoginDAO{
          UserName = username,
          HashedPassword = _hasher.ComputeHash(password),
          Role = new RoleDAO{Id=1}  
        });
        _dbContext.SaveChanges();
        return newUser.Entity;
    }
}
public class AlreadyAvailableCredentials : Exception{
    public AlreadyAvailableCredentials(string message):
        base(message)
    {
        
    }
} 