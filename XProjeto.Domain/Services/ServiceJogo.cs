using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XProjeto.Domain.Arguments.Base;
using XProjeto.Domain.Arguments.Jogo;
using XProjeto.Domain.Entities;
using XProjeto.Domain.Interfaces.Repositories;
using XProjeto.Domain.Interfaces.Services;
using XProjeto.Domain.Resources;

namespace XProjeto.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        protected ServiceJogo()
        {

        }

        public ServiceJogo(IRepositoryJogo repositoryJogo)
        {
            _repositoryJogo = repositoryJogo;
        }

        public AdicionarJogoResponse AdicionarJogo(AdicionarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarJogoRequest"));
                return null;
            }

            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            if (this.IsInvalid())
            {
                return null;
            }

            jogo = _repositoryJogo.Adicionar(jogo);

            return (AdicionarJogoResponse)jogo;
        }

        public ResponseBase AlterarJogo(AlterarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Alterar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AlterarJogoRequest"));
                return null;
            }

            var jogo = _repositoryJogo.ObterPorId(request.Id);

            if (jogo == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            jogo.Alterar(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryJogo.Editar(jogo);

            return (ResponseBase)jogo;
        }

        public ResponseBase ExcluirJogo(Guid id)
        {
            var jogo = _repositoryJogo.ObterPorId(id);

            if (jogo == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryJogo.Remover(jogo);

            return (ResponseBase)jogo;
        }

        public IEnumerable<JogoResponse> ListarJogo()
        {
            return _repositoryJogo.Listar().ToList().Select(jogo => (JogoResponse)jogo).ToList();
        }
    }
}