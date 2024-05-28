using Microsoft.EntityFrameworkCore;

namespace FortuneTellerApi.Models
{
    public class APIDbContext:DbContext
    {
      public  APIDbContext(DbContextOptions option):base(option) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserRefreshTokens> UserRefreshToken { get; set; }
        public DbSet<DailyMessage> DailyMessages { get; set; }
        public DbSet<FortuneTeller> FortuneTellers { get; set; }
        public DbSet<FortuneImageInfo> FortuneImageInfos { get; set; }
        public DbSet<FortuneDetail> FortuneDetails { get; set; }
        public DbSet<FortuneInfo> FortuneInfos { get; set; }
        public DbSet<FortunePrice> FortunePrices { get; set; }
        public DbSet<HoroscopeInfo> HoroscopeInfos { get; set; }
        public DbSet<WeeklyHoroscopeMessage> WeeklyHoroscopeMessages { get; set; }
    }
}
