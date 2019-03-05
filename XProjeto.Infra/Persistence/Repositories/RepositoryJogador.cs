using System;
using XProjeto.Domain.Entities;
using XProjeto.Domain.Interfaces.Repositories;
using XProjeto.Infra.Persistence.Repositories.Base;

namespace XProjeto.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }

    }
}
