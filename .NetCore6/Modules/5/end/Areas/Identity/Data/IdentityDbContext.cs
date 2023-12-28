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
        
        IdentityRole<string> adminRole = new IdentityRole() {
                Id = Guid.NewGuid().ToString(), 
                Name = "Administrator", 
                ConcurrencyStamp = "1", 
                NormalizedName = "ADMINISTRATOR"
                };
        builder.Entity<IdentityRole>().HasData(adminRole); 

        IdentityUser roleUser = CreateUser("Admin@globomantics.com"); 
        builder.Entity<IdentityUser>().HasData(roleUser); 

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { 
                UserId = roleUser.Id, 
                RoleId = adminRole.Id
                }
        );

        IdentityUser claimUser = CreateUser("SuperAdmin@globomantics.com"); 
        builder.Entity<IdentityUser>().HasData(claimUser);  

        builder.Entity<IdentityUserClaim<string>>().HasData(
            new IdentityUserClaim<string>() { 
                UserId = claimUser.Id,
                Id = 1,
                ClaimType = "IsManager", 
                ClaimValue = "true"
                }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { 
                UserId = claimUser.Id, 
                RoleId = adminRole.Id
                }
        );

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
