using GameZone.Models;

namespace GameZone.Data
{
    public class ApplicationDb :DbContext

    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options)
            :base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category { Id=1,Name="sports"},
                    new Category { Id=2,Name="action"},
                    new Category { Id=3,Name="advanture"},
                    new Category { Id=4,Name="racing"},
                    new Category { Id=5,Name="fight"},
                    new Category { Id=6,Name="film"},
                });
            modelBuilder.Entity<Device>()
                .HasData(new Device[] { 
                new Device {Id =1 , Name="xbox",Icon="bi bi-xbox"},
                new Device {Id =2 , Name="playstation",Icon="bi bi-playstaion"},
                new Device {Id =3 , Name="pc",Icon="bi bi-pc"},
                new Device {Id =4 , Name="switch",Icon="bi bi-swich"},
                });
            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.GameId, e.DeviceId }); // hena relation m to m ..>rage3 ef
            base.OnModelCreating(modelBuilder);
        }
    }
}
