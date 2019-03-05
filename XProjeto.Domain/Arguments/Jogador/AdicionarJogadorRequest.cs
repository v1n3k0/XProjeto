using XProjeto.Domain.Interfaces.Arguments;
using XProjeto.Domain.ValueObjects;

namespace XProjeto.Domain.Arguments.Jogador
{
    public class AdicionarJogadorRequest : IRequest
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }
    }
}
