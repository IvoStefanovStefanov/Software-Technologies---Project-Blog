using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Biliana_Georgieva_Blog.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<H2HPost> H2HPosts { get; set; }
        public DbSet<H2HComment> H2HComments { get; set; }
        //public DbSet<WrittenConv> WritenConvComments { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Biliana_Georgieva_Blog.Models.WrittenConv> WrittenConvs { get; set; }

        public System.Data.Entity.DbSet<Biliana_Georgieva_Blog.Models.WrittenConvComment> WrittenConvComments { get; set; }
    }
}