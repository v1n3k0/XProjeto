using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProjeto.Infra.Persistence;

namespace XProjeto.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XGameContext _context;

        public UnitOfWork(XGameContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
