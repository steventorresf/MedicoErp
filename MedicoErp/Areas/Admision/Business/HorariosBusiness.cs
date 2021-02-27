using MedicoErp.Areas.Admision.Entities;
using MedicoErp.Areas.General.Business;
using MedicoErp.Models;
using MedicoErp.Utiles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.Admision.Business
{
    public class HorariosBusiness
    {
        public void Creates(List<Horarios> Listado)
        {
            try
            {
                BaseContext context = new BaseContext();
                context.Horarios.AddRange(Listado);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("CreatesHorarios", ex.Message, null);
                throw;
            }
        }

        public List<Horarios> GetHorariosMedico(int IdMedico)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Horarios> Lista = (from ho in context.Horarios.Where(x => x.IdMedico == IdMedico)
                                        join es in context.TablasDetalles.Where(x => x.CodTabla.Equals(Constantes.TabEstados)) on ho.CodEstado equals es.CodValor
                                        select new Horarios()
                                        {
                                            IdHorario = ho.IdHorario,
                                            Fecha = ho.Fecha,
                                            HoraInicial = ho.HoraInicial,
                                            HoraFinal = ho.HoraFinal,
                                            IdMedico = ho.IdMedico,
                                            CodEstado = ho.CodEstado,
                                            IdCentro = ho.IdCentro,
                                            SHoraInicial = ho.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-EU")),
                                            SHoraFinal = ho.HoraFinal.ToString("hh:mm tt", new CultureInfo("en-EU")),
                                            NombreEstado = es.Descripcion,
                                        }).OrderBy(x => x.HoraInicial).OrderBy(x => x.Fecha).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("ControllerGetHorariosMedico", ex.Message, null);
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
                    List<Horarios> ListaHor = GetListHorarios(Fechas, HoraI, Min, Num, IdMedico, IdCentro);
                    Creates(ListaHor);
                }

                return Cad;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetSCreatesHorarios", ex.Message, null);
                throw;
            }
        }

        public string GetValidacionHorasFecha(DateTime[] Fechas, DateTimeOffset HoraI, DateTimeOffset HoraF, int IdMedico)
        {
            try
            {
                string Cad = "";
                BaseContext context = new BaseContext();
                List<Horarios> Lista = context.Horarios.Where(x => x.IdMedico == IdMedico && x.Fecha >= DateTime.Now.Date).ToList();
                foreach(DateTime Fecha in Fechas)
                {
                    var lista = Lista.Where(x => x.Fecha == Fecha &&
                                           ((x.HoraInicial < HoraI && x.HoraFinal > HoraI) ||
                                           (x.HoraInicial >= HoraI && x.HoraInicial < HoraF) ||
                                           (x.HoraFinal < HoraI && x.HoraFinal > HoraF))).ToList();
                    if(lista.Count > 0)
                    {
                        Cad += "Existe cruce en la fecha: <b>" + Fecha.ToString("dd/MM/yyyy") + "</b><br>";
                    }
                }
                return Cad;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetValidacionHorasFecha", ex.Message, null);
                throw;
            }
        }

        public List<Horarios> GetListHorarios(DateTime[] Fechas, DateTimeOffset HoraI, short Min, short Num, int IdMedico, int IdCentro)
        {
            try
            {
                List<Horarios> Lista = new List<Horarios>();
                foreach (DateTime Fecha in Fechas)
                {
                    DateTimeOffset HoraIni = HoraI;
                    DateTimeOffset HoraFin = HoraIni.AddMinutes(Min);

                    for (short i = 0; i < Num; i++)
                    {
                        Horarios ob = new Horarios();
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
                ErroresBusiness.Create("GetListHorario", ex.Message, null);
                throw;
            }
        }

        public string[] GetFechasMed(int IdMedico)
        {
            try
            {
                BaseContext context = new BaseContext();
                string[] Lista = context.Horarios.Where(x => x.IdMedico == IdMedico && x.CodEstado.Equals("LI"))
                                                 .Select(x => x.Fecha.ToString("yyyy-MM-dd")).Distinct().ToArray();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFechasMed", ex.Message, null);
                throw;
            }
        }

        public List<Horarios> GetFechaHorasMed(int IdMedico, DateTime Fecha)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Horarios> Lista = (from ho in context.Horarios.Where(x => x.IdMedico == IdMedico && x.Fecha == Fecha && x.CodEstado.Equals("LI"))
                                        select new Horarios()
                                        {
                                            IdHorario = ho.IdHorario,
                                            Fecha = ho.Fecha,
                                            HoraInicial = ho.HoraInicial,
                                            HoraFinal = ho.HoraFinal,
                                            SHoraInicial = ho.HoraInicial.ToString("hh:mm tt", new CultureInfo("en-EU")) + " - " + ho.HoraFinal.ToString("hh:mm tt", new CultureInfo("en-EU")),
                                            SHoraFinal = ho.HoraFinal.ToString("hh:mm tt", new CultureInfo("en-EU")),
                                            CodEstado = ho.CodEstado,
                                            IdMedico = ho.IdMedico,
                                            IdCentro = ho.IdCentro,
                                        }).OrderBy(x => x.HoraInicial).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetFechaHorasMed", ex.Message, null);
                throw;
            }
        }

    }
}
