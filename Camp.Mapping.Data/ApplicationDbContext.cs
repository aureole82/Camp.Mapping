using Camp.Mapping.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Camp.Mapping.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, RoleModel, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PostModel> Posts { get; set; }
    }
}