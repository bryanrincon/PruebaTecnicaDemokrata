using DemokrataBryan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemokrataBryan.Business.Interfaces
{
    public interface IUsuariosBL
    {
        Task<Response> GetById(int id);
        Task<Response> GetUsers(string nombre = "", string apellido = "", int page = 1, int pageSize = 10);
        Task<Response> Create(UsuarioDto usuarioDto);
        Task<Response> Update(int id, UsuarioDto usuarioDto);
        Task<Response> Delete(int id);
    }
}
