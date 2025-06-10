using LinkDev.IKEA.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Contacts
{
    public interface IDbInitializer
    {
        void initialize();
        void Seed();
        Task SeedUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole>
            roleManager);
    }
}
