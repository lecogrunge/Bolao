using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bolao.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BolaoContext context;
        private IUserRepository userRepository;
        private ILotteryReposiory lotteryRepository;
        private IUserSecurityRepository userSecurityRepository;
        private IDbContextTransaction transaction;

        public UnitOfWork(BolaoContext context)
        {
            this.context = context;
        }

        public void OpenTransaction()
        {
            this.transaction = this.context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.transaction.Commit();
        }

        public void RollBackTransaction()
        {
            this.transaction.Rollback();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IUserRepository UserRepository => this.userRepository = this.userRepository ?? new UserRepository(this.context);

        public ILotteryReposiory LotteryReposiory => this.lotteryRepository = this.lotteryRepository ?? new LotteryRepository(this.context);

        public IUserSecurityRepository UserSecurityRepository => this.userSecurityRepository  = this.userSecurityRepository ?? new UserSecurityRepository(this.context);
    }
}