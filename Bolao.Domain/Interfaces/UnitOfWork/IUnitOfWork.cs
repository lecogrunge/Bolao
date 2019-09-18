using Bolao.Domain.Interfaces.Repositories;

namespace Bolao.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserSecurityRepository UserSecurityRepository { get; }
        ILotteryReposiory LotteryReposiory { get; }
        void Commit();
    }
}