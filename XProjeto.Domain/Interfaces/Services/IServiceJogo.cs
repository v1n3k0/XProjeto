using System;
using System.Collections.Generic;
using XProjeto.Domain.Arguments.Base;
using XProjeto.Domain.Arguments.Jogo;
using XProjeto.Domain.Interfaces.Services.Base;

namespace XProjeto.Domain.Interfaces.Services
{
    public interface IServiceJogo: IServiceBase
    {
        AdicionarJogoResponse AdicionarJogo(AdicionarJogoRequest request);

        ResponseBase AlterarJogo(AlterarJogoRequest request);

        ResponseBase ExcluirJogo(Guid request);

        IEnumerable<JogoResponse> ListarJogo();
    }
}
