using MedicoErp.Model.Abstract.Admision;
using MedicoErp.Model.Abstract.General;
using MedicoErp.Model.Common;
using MedicoErp.Model.Context;
using MedicoErp.Model.Entities.Admision;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoErp.Model.Business.Admision
{
    public class HorarioBusiness : IHorarioBusiness
    {
        private readonly IErrorBusiness errorBusiness;
        private readonly MedicoErpContext context;

        public HorarioBusiness(MedicoErpContext _context, IErrorBusiness _errorBusiness)
        {
            this.context = _context;
            this.errorBusiness = _errorBusiness;
        }


        public void Creates(List<Horario> Listado)
        {
            try
            {
                context.Horario.AddRange(Listado);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                errorBusiness.Create("CreatesHorarios", ex, null);
                throw;
            }
        }

        public List<Horario> GetHorariosMedico(int IdMedico)
        {
            try
            {
                List<Horario> Lista = (from ho in context.Horario.Where(x => x.IdMedico == IdMedico)
                                        join es in context.TablaDetalle.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ho.CodEstado equals es.CodValor
                                        select new Horario()
                                        {
                                            IdHorario = ho.IdHorario,
                                            Fecha = ho.Fecha,
                                            HoraInicial = ho.HoraInicial,
                                            HoraFinal = ho.HoraFinal,
                                            IdMedico = ho.IdMedico,
                                            CodEstado = ho.CodEstado,
                                            IdCentro = ho.IdCentro,
                                            SHoraInicial = ho.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US")),
                                            SHoraFinal = ho.HoraFinal.ToString("hh:mm tt", new CultureInfo("en-US")),
                                            NombreEstado = es.Descripcion,
                                        }).OrderBy(x => x.HoraInicial).OrderByDescending(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("ControllerGetHorariosMedico", ex, null);
                throw;
            }
        }

        public string GetSCreatesHorarios(JObject data)
        {
            try
            {
                DateTime[] Fechas = data["fechas"].ToObject<DateTime[]>();
                DateTimeOffset HoraI = data["horaInicial"].ToObject<DateTimeOffset>();
                DateTimeOffset HoraF = data["horaFinal"].ToObject<DateTimeOffset>();
                short Min = data["minPac"].ToObject<short>();
                short Num = data["numPac"].ToObject<short>();
                int IdMedico = data["idMedico"].ToObject<int>();
                int IdCentro = data["idCentro"].ToObject<int>();

                string Cad = GetValidacionHorasFecha(Fechas, HoraI, HoraF, IdMedico);
                if (Cad.Equals(""))
                {
                    List<Horario> ListaHor = GetListHorarios(Fechas, HoraI, Min, Num, IdMedico, IdCentro);
                    Creates(ListaHor);
                }

                return Cad;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetSCreatesHorarios", ex, null);
                throw;
            }
        }

        public string GetValidacionHorasFecha(DateTime[] Fechas, DateTimeOffset HoraI, DateTimeOffset HoraF, int IdMedico)
        {
            try
            {
                string Cad = "";
                List<Horario> Lista = context.Horario.Where(x => x.IdMedico == IdMedico && x.Fecha >= DateTime.Now.Date).ToList();
                foreach (DateTime Fecha in Fechas)
                {
                    var lista = Lista.Where(x => x.Fecha == Fecha &&
                                           ((x.HoraInicial < HoraI && x.HoraFinal > HoraI) ||
                                           (x.HoraInicial >= HoraI && x.HoraInicial < HoraF) ||
                                           (x.HoraFinal < HoraI && x.HoraFinal > HoraF))).ToList();
                    if (lista.Count > 0)
                    {
                        Cad += "Existe cruce en la fecha: <b>" + Fecha.ToString("dd/MM/yyyy") + "</b><br>";
                    }
                }
                return Cad;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetValidacionHorasFecha", ex, null);
                throw;
            }
        }

        public List<Horario> GetListHorarios(DateTime[] Fechas, DateTimeOffset HoraI, short Min, short Num, int IdMedico, int IdCentro)
        {
            try
            {
                List<Horario> Lista = new List<Horario>();
                foreach (DateTime Fecha in Fechas)
                {
                    DateTimeOffset HoraIni = HoraI;
                    DateTimeOffset HoraFin = HoraIni.AddMinutes(Min);

                    for (short i = 0; i < Num; i++)
                    {
                        Horario ob = new Horario();
                        ob.Fecha = Fecha;
                        ob.HoraInicial = HoraIni;
                        ob.HoraFinal = HoraFin;
                        ob.IdMedico = IdMedico;
                        ob.IdCentro = IdCentro;
                        ob.CodEstado = "LI";
                        Lista.Add(ob);

                        HoraIni = HoraIni.AddMinutes(Min);
                        HoraFin = HoraFin.AddMinutes(Min);
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetListHorario", ex, null);
                throw;
            }
        }

        public string[] GetFechasMed(int IdMedico)
        {
            try
            {
                string[] Lista = context.Horario.Where(x => x.IdMedico == IdMedico && x.CodEstado.Equals("LI"))
                                                .Select(x => x.Fecha.ToString("yyyy-MM-dd")).Distinct().ToArray();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFechasMed", ex, null);
                throw;
            }
        }

        public List<Horario> GetFechaHorasMed(int IdMedico, DateTime Fecha)
        {
            try
            {
                List<Horario> Lista = (from ho in context.Horario.Where(x => x.IdMedico == IdMedico && x.Fecha == Fecha && x.CodEstado.Equals("LI"))
                                       select new Horario()
                                       {
                                           IdHorario = ho.IdHorario,
                                           Fecha = ho.Fecha,
                                           HoraInicial = ho.HoraInicial,
                                           HoraFinal = ho.HoraFinal,
                                           SHoraInicial = ho.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-US")) + " - " + ho.HoraFinal.ToString("hh:mm tt", new CultureInfo("en-US")),
                                           SHoraFinal = ho.HoraFinal.ToString("hh:mm tt", new CultureInfo("en-US")),
                                           CodEstado = ho.CodEstado,
                                           IdMedico = ho.IdMedico,
                                           IdCentro = ho.IdCentro,
                                       }).OrderBy(x => x.HoraInicial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                errorBusiness.Create("GetFechaHorasMed", ex, null);
                throw;
            }
        }
    }
}
