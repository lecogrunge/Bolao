using Bolao.Domain.Domains;
using Bolao.Domain.ObjectValue;
using Bolao.Infra.Persistence.EF.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Bolao.Infra.Persistence.EF
{
    public class BolaoContext : DbContext
    //public class BolaoContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BolaoContext(DbContextOptions<BolaoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
		public DbSet<UserSecurity> UserSecurities { get; set; }
		public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<UserContactType> UsersContactTypes { get; set; }
        public DbSet<TypeBet> TypeBets { get; set; }
        public DbSet<Lottery> Lotteries { get; set; }
        public DbSet<LotteryNumberBet> LotteryNumbersBet { get; set; }
        public DbSet<LotteryNumberResult> LotteryNumbersResult { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<WinnerJackpot> WinnersJackpots { get; set; }
        public DbSet<OwnerJackpot> OwnerJackpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ignorar classes
            modelBuilder.Ignore<Email>();

            // aplicar configurações
            modelBuilder.ApplyConfiguration(new MapUser());
            modelBuilder.ApplyConfiguration(new MapUserSecurity());
            modelBuilder.ApplyConfiguration(new MapLotteryNumberResult());
            modelBuilder.ApplyConfiguration(new MapLotteryNumberBet());
            modelBuilder.ApplyConfiguration(new MapLottery());
            modelBuilder.ApplyConfiguration(new MapTypeBet());
            modelBuilder.ApplyConfiguration(new MapBank());
            modelBuilder.ApplyConfiguration(new MapWinnerJackpot());
            modelBuilder.ApplyConfiguration(new MapOwnerJackpot());
            modelBuilder.ApplyConfiguration(new MapBuy());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.Relational().TableName = entityType.DisplayName();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
            //this.Seed(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            //#region User
            //User user = new User("Wellington", "Fernandes", new Email("wellington.m.fernandes@gmail.com"), "123");
            //modelBuilder.Entity<User>().HasData(user);
            //#endregion

            //#region TypeBet
            //TypeBet typeBet = new TypeBet("Sena15Numbers", "Descição");
            
            //modelBuilder.Entity<TypeBet>().HasData(typeBet);
            //#endregion

            //#region Lottery
            //Lottery lottery = new Lottery(17, DateTime.Now, DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), typeBet.TypeBetId);
            //modelBuilder.Entity<TypeBet>().HasData(new TypeBet("Sena15Numbers", "Descição"));
            //#endregion

            //#region LotteryNumberResult            
            //#region Resultado 1
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("01", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("02", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("03", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("04", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("05", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("06", lottery.LoterryId));
            //#endregion

            //#region Resultado 2
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("07", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("08", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("09", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("10", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("11", lottery.LoterryId));
            //modelBuilder.Entity<TypeBet>().HasData(new LotteryNumberBet("12", lottery.LoterryId));
            //#endregion
            //#endregion
        }
    }
}