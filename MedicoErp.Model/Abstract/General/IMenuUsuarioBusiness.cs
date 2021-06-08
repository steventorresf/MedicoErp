using MedicoErp.Model.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.General
{
    public interface IMenuUsuarioBusiness
    {
        string GetMenuByIdUsuario(int IdUsuario);
        List<MenuUsuario> GetAllByIdUsuario(int IdUsuario);
        List<Menu> GetNotAllByIdUsuario(int IdUsuario);
        void Create(MenuUsuario entity);
        void Creates(List<MenuUsuario> lista);
        void Delete(int IdMenuUsuario);
    }
}
