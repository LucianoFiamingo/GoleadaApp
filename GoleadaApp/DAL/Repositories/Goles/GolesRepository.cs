﻿using DAL.Entities.EDMX;
using Entities.VM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GolesRepository : IGolesRepository
    {
        protected GoleadaDBEntities contexto;
        public GolesRepository(GoleadaDBEntities contexto)
        {
            this.contexto = contexto;
        }
        public void Alta(GolesPorJugadorEquipo Goles)
        {
            contexto.GolesPorJugadorEquipoes.Add(Goles);
            contexto.SaveChanges();
        }

        public void AltaModificacion(GolesPorJugadorEquipo Goles)
        {
            GolesPorJugadorEquipo GolesEncontrado = ObtenerPorEquipoYNombreJugador(Goles);
            if (GolesEncontrado != null)
            {
                GolesEncontrado.Cantidad = Goles.Cantidad;
                GolesEncontrado.Equipo = Goles.Equipo;
                GolesEncontrado.IdJugador = Goles.IdJugador;
            }
            else
            {
                contexto.GolesPorJugadorEquipoes.Add(Goles);
            }
            contexto.SaveChanges();
        }

        public GolesPorJugadorEquipo ObtenerPorEquipoYNombreJugador(GolesPorJugadorEquipo goles)
        {
            var GolesQuery = from g in contexto.GolesPorJugadorEquipoes
                             where g.Equipo == goles.Equipo 
                             & g.IdJugador == goles.IdJugador
                             select g;

            if (GolesQuery.Count() < 1)
            {
                return null;
            }
            GolesPorJugadorEquipo GolesEncontrado = GolesQuery.First();

            return GolesEncontrado;
        }

        public GolesPorJugadorEquipo ObtenerPorId(int Id)
        {
            var GolesQuery = from g in contexto.GolesPorJugadorEquipoes
                             where g.Id == Id
                             select g;

            GolesPorJugadorEquipo Goles = GolesQuery.First();

            return Goles;
        }

        public List<GolesPorJugadorEquipo> ObtenerTodos()
        {
            var GolesQuery = from g in contexto.GolesPorJugadorEquipoes
                             orderby g.Jugador.Nombre
                             select g;

            List<GolesPorJugadorEquipo> ListaGoles = GolesQuery.ToList();

            return ListaGoles;
        }
        public string TotalGolesEquipo(string equipo)
        {
            var GolesQuery = (from g in contexto.GolesPorJugadorEquipoes
                             where g.Equipo == equipo
                             select g.Cantidad).DefaultIfEmpty(0).Sum();

            string cant = GolesQuery.ToString();

            return cant;
        }
        
        public List<GolesEquipoVM> GolesPorEquipo()
        {
            var GolesEquipoQuery = from g in contexto.GolesPorJugadorEquipoes
                                            group g by g.Equipo into g
                                            select new GolesEquipoVM 
                                            { Equipo = g.Key, Cantidad = g.Sum(o => o.Cantidad), PromedioJugadores = g.Sum(o => o.Cantidad) / g.Count()};

            List<GolesEquipoVM> GolesEquipo = GolesEquipoQuery.ToList();

            return GolesEquipo;
        }
        /*
        public List<GolesEquipoVM> GolesPorEquipo()
        {
            var GolesEquipoQuery = from g in contexto.GolesPorJugadorEquipoes
                                   group g by new { g.Equipo, g.Cantidad } into g
                                   select new GolesEquipoVM
                                   { Equipo = g.Key.Equipo, Cantidad = g.Sum(x => x.Cantidad) };

            List<GolesEquipoVM> GolesEquipo = GolesEquipoQuery.ToList();

            return GolesEquipo;
        }
        */

    }
}