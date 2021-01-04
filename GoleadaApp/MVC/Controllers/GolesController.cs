using DAL.Entities.EDMX;
using Entities.DTO;
using Entities.VM;
using MVC.Models;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GolesController : Controller
    {
        private readonly GolesService GolesService;
        private readonly JugadoresService JugadoresService;
        public GolesController()
        {
            GoleadaDBEntities contexto = new GoleadaDBEntities();
            GolesService = new GolesService(contexto);
            JugadoresService = new JugadoresService(contexto);
        }
        public ActionResult ListaGolesJugador()
        {
            List<GolesPorJugadorEquipo> Goles = GolesService.ObtenerTodos();
            return View(Goles);
        }
        public ActionResult AltaGolesJugador()
        {
            ViewBag.ListaJugadores = JugadoresService.ObtenerComboJugadores();
            return View();
        }

        [HttpPost]
        public ActionResult AltaGolesJugador(GolesPorJugadorEquipo goles)
        {
            if (!ModelState.IsValid)
            {
                TempData["Creado"] = "FALSE";
                ViewBag.ListaJugadores = JugadoresService.ObtenerComboJugadores(goles.IdJugador);
                return View(goles);
            }

            GolesService.AltaModificacion(goles);
            TempData["Creado"] = JugadoresService.ObtenerPorId(goles.IdJugador).Nombre.ToString();
            return RedirectToAction("ListaGolesJugador");
        }

        public ActionResult GolesPruebaApi(string id)
        {
            ViewBag.Equipo = id;
            ViewBag.Cant = GetGolesEquipo(id);
            return View();
        }

        private string GetGolesEquipo(string id)
        {
            var url = $"https://localhost:44350/api/cantidadtotalgolesequipoapi/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return id;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<string>(responseBody);
                        return result;
                    }
                }
            }
        }

        public ActionResult GolesDTOApi()
        {
            List<GolesDTO> goles = GetGolesDTOApi();
            return View(goles);
        }

        private List<GolesDTO> GetGolesDTOApi()
        {
            var url = $"https://localhost:44350/api/golesdtoapi";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return new List<GolesDTO>();
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<List<GolesDTO>>(responseBody);
                        return result;
                    }
                }
            }
        }

        public ActionResult GolesServerSide()
        {
            return View();
        }
        public ActionResult GetData(JqueryDatatableParam param)
        {
            List<GolesDTO> employees = GetGolesDTOApi();

            //employees.ToList().ForEach(x => x.StartDateString = x.StartDate.ToString("dd'/'MM'/'yyyy"));

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                employees = employees.Where(x => x.Cantidad.ToString().Contains(param.sSearch.ToLower())
                                              || x.Equipo.ToLower().Contains(param.sSearch.ToLower())
                                              || x.NombreJugador.ToLower().Contains(param.sSearch.ToLower())).ToList();
            }

            var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
            var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];

            if (sortColumnIndex == 3)
            {
                employees = (sortDirection == "asc" ? employees.OrderBy(c => c.Cantidad).ToList() : employees.OrderByDescending(c => c.Cantidad).ToList());
            }
            else if (sortColumnIndex == 4)
            {
                employees = (sortDirection == "asc" ? employees.OrderBy(c => c.Equipo).ToList() : employees.OrderByDescending(c => c.Equipo).ToList());
            }
            else if (sortColumnIndex == 5)
            {
                employees = (sortDirection == "asc" ? employees.OrderBy(c => c.NombreJugador).ToList() : employees.OrderByDescending(c => c.NombreJugador).ToList());
            }
            else
            {
                Func<GolesDTO, string> orderingFunction = e => sortColumnIndex == 0 ? e.NombreJugador :
                                                               sortColumnIndex == 1 ? e.Equipo :
                                                               e.Cantidad.ToString();

                employees = sortDirection == "asc" ? employees.OrderBy(orderingFunction).ToList() : employees.OrderByDescending(orderingFunction).ToList();
            }

            var displayResult = employees.Skip(param.iDisplayStart)
                .Take(param.iDisplayLength).ToList();
            var totalRecords = employees.Count();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GolesEquipo()
        {
            List<GolesEquipoVM> golesEquipos = GolesService.GolesPorEquipo();
            return View(golesEquipos);
        }
    }
}