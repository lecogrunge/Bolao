using Bolao.Domain.Domains;
using Bolao.Domain.ObjectValue;
using Bolao.Infra.Persistence.EF.Map;
using Microsoft.EntityFrameworkCore;

namespace Bolao.Infra.Persistence.EF
{
    public class BolaoContext : DbContext
	{
		public BolaoContext(DbContextOptions<BolaoContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<TypeBet> TypeBets { get; set; }
		public DbSet<Lottery> Lotteries { get; set; }
		public DbSet<LotteryNumberBet> MegaSenaBetNumbers { get; set; }
		public DbSet<LotteryNumberResult> MegaSenaLotteryNumbers { get; set; }
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
			modelBuilder.ApplyConfiguration(new MapLotteryNumberResult());
			modelBuilder.ApplyConfiguration(new MapLotteryNumberBet());
			modelBuilder.ApplyConfiguration(new MapLottery());
			modelBuilder.ApplyConfiguration(new MapTypeBet());
            modelBuilder.ApplyConfiguration(new MapBank());
            modelBuilder.ApplyConfiguration(new MapWinnerJackpot());
            modelBuilder.ApplyConfiguration(new MapOwnerJackpot());

            base.OnModelCreating(modelBuilder);
		}
	}
}