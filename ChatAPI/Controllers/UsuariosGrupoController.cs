﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ChatAPI.Models;

namespace ChatAPI.Controllers
{
    /// <summary>
    /// Controlador de relação entre usuários e grupos.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosGrupoController : ApiController
    {
        /// <summary>
        /// Pedido GET de todas as relações entre usuários e grupos.
        /// </summary>
        /// <returns>Lista de objetos da classe UsuarioGrupo</returns>
        public IEnumerable<UsuariosGrupo> Get()
        {
            using (UsuariosGrupoDBContext dbContext = new UsuariosGrupoDBContext())
            {
                List<UsuariosGrupo> get = dbContext.UsuariosGrupo.ToList();

                return get;
            }
        }

        /// <summary>
        /// Pedido GET de todos os grupos de um usuário.
        /// </summary>
        /// <param name="id">RA do usuário</param>
        /// <returns>Lista de IDs dos grupos aos quais o usuário pertence</returns>
        public IEnumerable<int> Get(int id)
        {
            using (UsuariosGrupoDBContext dbContext = new UsuariosGrupoDBContext())
            {
                List<UsuariosGrupo> get = dbContext.UsuariosGrupo.Where(g => g.Usuario == id).ToList();

                List<int> ret = new List<int>();

                foreach (UsuariosGrupo u in get)
                {
                    ret.Add((int)u.Grupo);
                }

                return ret;
            }
        }
    }
}
