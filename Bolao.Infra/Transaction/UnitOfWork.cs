using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories;

namespace Bolao.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BolaoContext _context;

        private IUserRepository _userRepository;
        private ILotteryReposiory _lotteryRepository;
        private IUserSecurityRepository _userSecurityRepository;

        public UnitOfWork(BolaoContext context)
        {
            _context = context;
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
            get
            {
                return _userSecurityRepository = _userSecurityRepository ?? new UserSecurityRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}