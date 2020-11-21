using DAL.Entities.EDMX;
using Services;
using System.Web.Http;

namespace API.Controllers
{
    public class CantidadTotalGolesEquipoApiController : ApiController
    {
        GolesService GolesService;
        public CantidadTotalGolesEquipoApiController()
        {
            GoleadaDBEntities contexto = new GoleadaDBEntities();
            GolesService = new GolesService(contexto);
        }
        public string Get(string id)
        {
            string cant = GolesService.TotalGolesEquipo(id);
            return cant;
        }
    }
}
