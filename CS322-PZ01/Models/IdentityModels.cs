using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace CS322_PZ01.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Ime"), Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Display(Name = "Prezime"), Required]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [Display(Name = "Adresa"), Required]
        [StringLength(100)]
        public string Adresa { get; set; }
        
        [Display(Name = "Telefon"), Required]
        [StringLength(100)]
        public string Telefon { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<KategorijaModel> kategorija { get; set; }
        public DbSet<Automobil> auto { get; set; }
        public DbSet<ProizvodModel> proizvod { get; set; }
        public DbSet<NarudzbinaModel> narudzbina { get; set; }
        public DbSet<Komentari> komentari { get; set; }
        public DbSet<Odgovori> odgovori { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}