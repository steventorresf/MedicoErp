using MedicoErp.Model.Common;
using MedicoErp.Model.Entities.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.General
{
    public interface IUsuarioBusiness
    {
        Cookie PostLogin(Login data);
        List<Usuario> GetUsuarios(int IdCentro);
        string GetFilePdf(int IdUsuario);
        void SetFilePdf(int IdUsuario, string Pdf);
        List<Usuario> GetMedicos(int IdCentro);
        void Create(Usuario entity);
        void Update(int IdUsuario, Usuario entity);
        void Activar(int IdUsuario);
        void Inactivar(int IdUsuario);
        void ResetearClave(int IdUsuario);
        int UpdateContraseña(JObject data);
    }
}
