using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XProjeto.Domain.Entities.Base;
using XProjeto.Domain.Enum;
using XProjeto.Domain.Extensions;
using XProjeto.Domain.Resources;
using XProjeto.Domain.ValueObjects;

namespace XProjeto.Domain.Entities
{
    public class Jogador : EntityBase
    {
        protected Jogador()
        {

        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres.");

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }

        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this).
                IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }            

            AddNotifications(nome, email);
        }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador status)
        {
            Nome = nome;
            Email = email;

            new AddNotifications<Jogador>(this).IfFalse(Status == EnumSituacaoJogador.Ativo, "Só é possível alterar jogador se ele estiver ativo.");

            AddNotifications(nome, email);
        }

        public Guid Id { get; private set; }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return this.Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }
    }
}
