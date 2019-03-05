using System;
using XProjeto.Domain.Interfaces.Arguments;

namespace XProjeto.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entidade)
        {
            return new AdicionarJogadorResponse()
            {
                Id = entidade.Id,
                Message = XProjeto.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
