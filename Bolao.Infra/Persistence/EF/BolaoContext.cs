using Bolao.Domain.Domains;
using Bolao.Domain.ObjectValue;
using Bolao.Infra.Persistence.EF.Map;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bolao.Infra.Persistence.EF
{
	public class BolaoContext : DbContext
	{
		public BolaoContext(DbContextOptions<BolaoContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<TypeBet> TypeBets { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<MegaSenaBetNumber> MegaSenaBetNumbers { get; set; }
		public DbSet<MegaSenaLottery> MegaSenaLotteries { get; set; }
		public DbSet<MegaSenaLotteryNumber> MegaSenaLotteryNumbers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// ignorar classes
			modelBuilder.Ignore<Email>();

			// aplicar configurações
			modelBuilder.ApplyConfiguration(new MapUser());
			modelBuilder.ApplyConfiguration(new MapMegaSenaLottery());
			modelBuilder.ApplyConfiguration(new MapMegaSenaLotteryNumber());
			modelBuilder.ApplyConfiguration(new MapMegaSenaBetNumber());
			modelBuilder.ApplyConfiguration(new MapTicket());
			modelBuilder.ApplyConfiguration(new MapTypeBet());

			base.OnModelCreating(modelBuilder);
		}

		private void Seed(ModelBuilder modelBuilder)
		{
			#region User
			modelBuilder.Entity<User>(options =>
			{
			options.HasData(
				new User("Wellington", "Fernandes", new Email("wellington_fernands@yahoo.com.br"), "123456"));
			});
			#endregion

			#region Mega Sena Loterry
			modelBuilder.Entity<MegaSenaLottery>(options =>
			{
				options.HasData(
					new MegaSenaLottery(DateTime.Now));
			});
			#endregion

			//#region Mega Sena Loterry Numbers
			//modelBuilder.Entity<MegaSenaLotteryNumber>(options =>
			//{
			//	options.HasData(
			//		new MegaSenaLotteryNumber("01", ));
			//});
			//#endregion
		}
	}
}