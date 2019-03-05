using XProjeto.Domain.Interfaces.Arguments;

namespace XProjeto.Domain.Arguments.Jogador
{
    public class AutenticarJogadorRequest : IRequest
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
