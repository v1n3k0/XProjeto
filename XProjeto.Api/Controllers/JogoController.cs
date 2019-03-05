using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XProjeto.Api.Controllers.Base;
using XProjeto.Domain.Arguments.Jogo;
using XProjeto.Domain.Interfaces.Services;
using XProjeto.Infra.Transactions;

namespace XProjeto.Api.Controllers
{
    [RoutePrefix("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly IServiceJogo _serviceJogo;

        public JogoController(IUnitOfWork unitOfWork, IServiceJogo serviceJogo) : base(unitOfWork)
        {
            _serviceJogo = serviceJogo;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AdicionarJogo(request);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Authorize]
        [Route("Excluir")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Excluir(Guid id)
        {
            try
            {
                var response = _serviceJogo.ExcluirJogo(id);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AlterarJogo(request);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceJogo.ListarJogo();

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}