using Bolao.Domain.Domains;
using Bolao.Domain.Enum;
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
		public DbSet<MegaSenaLottery> MegaSenaLotteries { get; set; }
		public DbSet<MegaSenaBetNumber> MegaSenaBetNumbers { get; set; }
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
				new User("Wellington", "Fernandes", new Email("wellington_fernands@yahoo.com.br"), "123456")
				);
			});
			#endregion

			#region TypeBet
			modelBuilder.Entity<TypeBet>(options =>
			{
				options.HasData(
					new TypeBet("Sena15Numbers")
					);
			});
			#endregion

			#region Ticket
			modelBuilder.Entity<Ticket>(options =>
			{
				options.HasData(
					new Ticket(20, true, DateTime.Now, DateTime.Now.AddDays(10), EnumTypeBet.Sena15Numbers),
					new Ticket(12, false, DateTime.Now.AddDays(5), DateTime.Now.AddDays(9), EnumTypeBet.Sena15Numbers),
					new Ticket(17, true, DateTime.Now.AddDays(3), DateTime.Now.AddDays(7), EnumTypeBet.Sena15Numbers)
					);
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