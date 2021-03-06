﻿using MedicoErp.Model.Entities.HistoriaClinica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Abstract.HistoriaClinica
{
    public interface IOrdenBusiness
    {
        List<Orden> GetAllByIdEvento(long IdEvento);
        List<Orden> GetAllByIdPaciente(long IdPaciente);
        void Create(Orden entity);
        int Anular(JObject data);
        Orden GetOrdenImp(long IdOrden);
    }
}
