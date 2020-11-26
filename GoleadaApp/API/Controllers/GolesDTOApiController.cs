using DAL.Entities.EDMX;
using Entities.DTO;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class GolesDTOApiController : ApiController
    {
        GolesService GolesService;
        public GolesDTOApiController()
        {
            GoleadaDBEntities contexto = new GoleadaDBEntities();
            GolesService = new GolesService(contexto);
        }
        public List<GolesDTO> Get()
        {
            List<GolesPorJugadorEquipo> goles = GolesService.ObtenerTodos();

            List<GolesDTO> golesDTO = new List<GolesDTO>();
            foreach (var item in goles)
            {
                GolesDTO golDTO = new GolesDTO();
                golDTO.Id = item.Id;
                golDTO.Cantidad = item.Cantidad;
                golDTO.Equipo = item.Equipo;
                golDTO.NombreJugador = item.Jugador.Nombre;

                golesDTO.Add(golDTO);
            }

            return golesDTO;
        }
    }
}
