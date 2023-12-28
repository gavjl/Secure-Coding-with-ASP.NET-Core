using Globomantics.Survey.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Globomantics.Survey.Data;

public class IdentityDbContext : IdentityDbContext<GloboSurveyUser>
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

        IdentityUser roleUser = CreateUser(
            "Admin@globomantics.com",
            "Globo Admin",
            new DateTime(2000, 01, 01),
            new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9901")
            ); 
        builder.Entity<GloboSurveyUser>().HasData(roleUser); 

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { 
                UserId = roleUser.Id, 
                RoleId = adminRole.Id
                }
        );

        IdentityUser claimUser = CreateUser(
            "SuperAdmin@globomantics.com",
            "Globo Super Admin",
            new DateTime(2000, 01, 01),
            new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9902")); 
        builder.Entity<GloboSurveyUser>().HasData(claimUser);  

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

    private IdentityUser CreateUser(string email, string name, DateTime dob, Guid id)
    {
        GloboSurveyUser user = new GloboSurveyUser()  
        {  
            Id = id.ToString(),  
            UserName = email,  
            NormalizedUserName = email.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = true,
            Name = name,
            DOB = dob
        };  

        PasswordHasher<GloboSurveyUser> passwordHasher = new PasswordHasher<GloboSurveyUser>();  
        user.PasswordHash = passwordHasher.HashPassword(user, email);
        return user;
    }
}
