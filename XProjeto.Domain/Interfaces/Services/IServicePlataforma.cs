using XProjeto.Domain.Arguments.Plataforma;

namespace XProjeto.Domain.Interfaces.Services
{
    public interface IServicePlataforma
    {

        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);
    }
}
