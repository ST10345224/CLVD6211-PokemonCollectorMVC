using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCollectorMVC.Areas.Identity.Data;

namespace PokemonCollectorMVC.Data;

public class PokemonCollectorMVCContext : IdentityDbContext<PokemonCollectorMVCUser>
{
    public PokemonCollectorMVCContext(DbContextOptions<PokemonCollectorMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplciationUserEntityConfiguration());
    }
}

public class ApplciationUserEntityConfiguration : IEntityTypeConfiguration<PokemonCollectorMVCUser>
{
    public void Configure(EntityTypeBuilder<PokemonCollectorMVCUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);

    }
}
