using System;
using System.Collections.Generic;
using XProjeto.Domain.Arguments.Base;
using XProjeto.Domain.Arguments.Jogador;
using XProjeto.Domain.Interfaces.Services.Base;

namespace XProjeto.Domain.Interfaces.Services
{
    public interface IServiceJogador : IServiceBase
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);

        AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> ListarJogador();

        ResponseBase ExcluirJogador(Guid id);
    }
}
