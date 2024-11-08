using AutoMapper;
using DemokrataBryan.Business.Interfaces;
using DemokrataBryan.Data;
using DemokrataBryan.Entities;
using DemokrataBryan.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemokrataBryan.Business
{
    public class UsuariosBL : IUsuariosBL
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuariosBL(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para obtener usuario por Id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Objeto Response donde indica los siguientes valores success si la ejecucion es exitosa y el resultado es el esperado,
        /// error si en la ejecucion genero algun error, message que indica un mensaje controlado y result que indica el resultado en formato json</returns>
        public async Task<Response> GetById(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response { error = false, success = false, message = $"No se encontró el usuario con id {id}" };
                }

                return new Response { error = false, success = true, message = "Usuario encontrado", result = usuario };
            }
            catch (Exception ex)
            {
                return new Response { error = true, success = false, message = "Esta operación genero un error", result = ex.Message };
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de usuarios
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Primer apellido del usuario</param>
        /// <param name="page">Pagina</param>
        /// <param name="pageSize">Tamaño de la pagina</param>
        /// <returns>Objeto Response donde indica los siguientes valores success si la ejecucion es exitosa y el resultado es el esperado,
        /// error si en la ejecucion genero algun error, message que indica un mensaje controlado y result que indica el resultado en formato json</returns>
        public async Task<Response> GetUsers(string nombre = "", string apellido = "", int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.Usuarios.Where(u => !u.IsDeleted).AsQueryable();

                if (!string.IsNullOrEmpty(nombre))
                {
                    query = query.Where(u => u.PrimerNombre.Contains(nombre));
                }

                if (!string.IsNullOrEmpty(apellido))
                {
                    query = query.Where(u => u.PrimerApellido.Contains(apellido));
                }

                var totalUsuarios = await query.CountAsync();
                var usuarios = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                if (!usuarios.Any())
                {
                    return new Response { error = false, success = false, message = "No se encontraron usuarios" };
                }
                return new Response { error = false, success = true, message = "Usuarios encontrados", result = new { TotalUsuarios = totalUsuarios, Usuarios = usuarios } };
            }
            catch (Exception ex)
            {
                return new Response { error = true, success = false, message = "Esta operación genero un error", result = ex.Message };
            }
        }

        /// <summary>
        /// Metodo para crear un usuario
        /// </summary>
        /// <param name="usuarioDto">Objeto request de usuario</param>
        /// <returns>Objeto Response donde indica los siguientes valores success si la ejecucion es exitosa y el resultado es el esperado,
        /// error si en la ejecucion genero algun error, message que indica un mensaje controlado y result que indica el resultado en formato json</returns>
        public async Task<Response> Create(UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response { error = false, success = true, message = "Usuario creado correctamente", result = usuario.Id };
            }
            catch (Exception ex)
            {
                return new Response { error = true, success = false, message = "Esta operación genero un error", result = ex.Message };
            }
        }

        /// <summary>
        /// Metodo para actualizar los datos del usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="usuarioDto">Objeto request de usuario</param>
        /// <returns>Objeto Response donde indica los siguientes valores success si la ejecucion es exitosa y el resultado es el esperado,
        /// error si en la ejecucion genero algun error, message que indica un mensaje controlado y result que indica el resultado en formato json</returns>
        public async Task<Response> Update(int id, UsuarioDto usuarioDto)
        {
            try
            {
                var usuarioExistente = await _context.Usuarios.FindAsync(id);
                if (usuarioExistente == null)
                {
                    return new Response { error = false, success = false, message = $"No se encontró el usuario con id {id}" };
                }

                var usuario = _mapper.Map<Usuario>(usuarioDto);

                usuarioExistente.PrimerNombre = usuario.PrimerNombre;
                usuarioExistente.SegundoNombre = usuario.SegundoNombre;
                usuarioExistente.PrimerApellido = usuario.PrimerApellido;
                usuarioExistente.SegundoApellido = usuario.SegundoApellido;
                usuarioExistente.FechaNacimiento = usuario.FechaNacimiento;
                usuarioExistente.Sueldo = usuario.Sueldo;
                usuarioExistente.FechaModificacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return new Response { error = false, success = true, message = "Usuario actualizado correctamente" };
            }
            catch (Exception ex)
            {
                return new Response { error = true, success = false, message = "Esta operación genero un error", result = ex.Message };
            }
        }

        /// <summary>
        /// Metodo que hace borrado logico del usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Objeto Response donde indica los siguientes valores success si la ejecucion es exitosa y el resultado es el esperado,
        /// error si en la ejecucion genero algun error, message que indica un mensaje controlado y result que indica el resultado en formato json</returns>
        public async Task<Response> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response { error = false, success = false, message = $"No se encontró el usuario con id {id}" };
                }

                usuario.IsDeleted = true;
                usuario.FechaModificacion = DateTime.Now;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response { error = false, success = true, message = "Usuario borrado correctamente" };
            }
            catch (Exception ex)
            {
                return new Response { error = true, success = false, message = "Esta operación genero un error", result = ex.Message };
            }
        }
    }
}
