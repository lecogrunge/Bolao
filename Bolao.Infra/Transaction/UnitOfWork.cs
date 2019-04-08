using Bolao.Infra.Persistence.EF;

namespace Bolao.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BolaoContext _context;

        public UnitOfWork(BolaoContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}