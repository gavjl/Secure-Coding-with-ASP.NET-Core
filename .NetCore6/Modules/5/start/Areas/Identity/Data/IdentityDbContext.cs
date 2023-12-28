using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Globomantics.Survey.Data;

public class IdentityDbContext : IdentityDbContext<IdentityUser>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        IdentityUser roleUser = CreateUser("Admin@globomantics.com"); 
        builder.Entity<IdentityUser>().HasData(roleUser); 

        IdentityUser claimUser = CreateUser("SuperAdmin@globomantics.com"); 
        builder.Entity<IdentityUser>().HasData(claimUser); 

    }

    private IdentityUser CreateUser(string email)
    {
        IdentityUser user = new IdentityUser()  
        {  
            Id = Guid.NewGuid().ToString(),  
            UserName = email,  
            NormalizedUserName = email.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = true
        };  

        PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();  
        user.PasswordHash = passwordHasher.HashPassword(user, email);
        return user;
    }
}
