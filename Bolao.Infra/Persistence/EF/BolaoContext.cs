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
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<MegaSenaBetNumber> MegaSenaBetNumbers { get; set; }
        public DbSet<MegaSenaLottery> MegaSenaLotteries { get; set; }
        public DbSet<MegaSenaLotteryNumber> MegaSenaLotteryNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignorar classes
            modelBuilder.Ignore<Email>();

            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapUser());
            modelBuilder.ApplyConfiguration(new MapMegaSenaBetNumber());
            modelBuilder.ApplyConfiguration(new MapMegaSenaLottery());
            modelBuilder.ApplyConfiguration(new MapMegaSenaLotteryNumber());
            modelBuilder.ApplyConfiguration(new MapTicket());
            modelBuilder.ApplyConfiguration(new MapTypeBet());

            base.OnModelCreating(modelBuilder);
        }
    }
}