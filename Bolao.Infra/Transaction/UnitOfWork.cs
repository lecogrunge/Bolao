using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bolao.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BolaoContext _context;
        private IUserRepository _userRepository;
        private ILotteryReposiory _lotteryRepository;
        private IUserSecurityRepository _userSecurityRepository;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BolaoContext context)
        {
            _context = context;
        }

        public void OpenTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollBackTransaction()
        {
            _transaction.Rollback();
        }

        public void SaveIB()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public ILotteryReposiory LotteryReposiory
        {
            get
            {
                return _lotteryRepository = _lotteryRepository ?? new LotteryRepository(_context);
            }
        }

        public IUserSecurityRepository UserSecurityRepository
        {
            get => _userSecurityRepository ?? new UserSecurityRepository(_context);
        }
    }
}