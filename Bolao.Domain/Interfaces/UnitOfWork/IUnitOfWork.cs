using Bolao.Domain.Interfaces.Repositories;
using System;

namespace Bolao.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserSecurityRepository UserSecurityRepository { get; }
        ILotteryReposiory LotteryReposiory { get; }

        void SaveIB();

        void OpenTransaction();

        void CommitTransaction();

        void RollBackTransaction();
    }
}