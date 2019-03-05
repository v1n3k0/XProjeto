using System;
using XProjeto.Domain.Entities;
using XProjeto.Domain.Interfaces.Repositories;
using XProjeto.Infra.Persistence.Repositories.Base;

namespace XProjeto.Infra.Persistence.Repositories
{
    public class RepositoryJogo : RepositoryBase<Jogo, Guid>, IRepositoryJogo
    {
        protected readonly XGameContext _context;

        public RepositoryJogo(XGameContext context) : base(context)
        {
            _context = context;
        }

    }
}
