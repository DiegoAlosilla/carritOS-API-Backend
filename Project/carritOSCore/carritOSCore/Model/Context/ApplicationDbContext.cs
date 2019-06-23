using carritOSCore.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carritOSCore.Model.Context
{
    public partial class ApplicationDbContext:IdentityDbContext<AplicationUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {
        }

        public DbSet<BusinessOwner> BusinessOwners { get; set; }
    }
}
