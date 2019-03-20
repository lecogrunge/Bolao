namespace Bolao.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}