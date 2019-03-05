using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XProjeto.Domain.Arguments.Jogador;
using XProjeto.Domain.Entities;
using XProjeto.Domain.Interfaces.Repositories;
using XProjeto.Domain.Interfaces.Services;
using XProjeto.Domain.Resources;
using XProjeto.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using XProjeto.Domain.Arguments.Base;

namespace XProjeto.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }

        public ServiceJogador(IRepositoryJogador _repositoryJogador)
        {
            this._repositoryJogador = _repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);
            
            Jogador jogador = new Jogador(nome, email, request.Senha);

            AddNotifications(nome, email);

            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.Adicionar(jogador);

            return (AdicionarJogadorResponse) jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);

            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador);

            if (IsInvalid())
            {
                return null;
            }

            _repositoryJogador.Editar(jogador);
            
            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador);

            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco && x.Senha == jogador.Senha);
            
            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.Listar().ToList().Select(jogador => (JogadorResponse) jogador).ToList();
        }

        public ResponseBase ExcluirJogador(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);

            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryJogador.Remover(jogador);

            return new ResponseBase();
        }

    }
}