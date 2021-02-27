using MedicoErp.Areas.General.Entities;
using MedicoErp.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoErp.Areas.General.Business
{
    public class MenuUsuarioBusiness
    {
        public string GetMenuByIdUsuario(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Menu> Lista = (from mu in context.MenuUsuarios.Where(x => x.IdUsuario == IdUsuario)
                                    join me in context.Menu on mu.IdMenu equals me.IdMenu
                                    select new Menu()
                                    {
                                        IdMenu = me.IdMenu,
                                        Codigo = me.Codigo,
                                        Nombre = me.Nombre,
                                        Descripcion = me.Descripcion,
                                        CodPadre = me.CodPadre,
                                    }).ToList();

                string MenuHtml = "";
                foreach(Menu m in Lista)
                {
                    MenuHtml += "|" + m.Codigo + "|";
                }
                //string MenuHtml = "<li><a href='Home'><i class='icon-home'></i>Home </a></li>";
                //List<Menu> ListaMenu = Lista.Where(x => x.IdPadre == null).ToList();
                //foreach (Menu m in ListaMenu)
                //{
                //    MenuHtml += "<li>";
                //    MenuHtml += "<a href='#Dropdown" + m.IdMenu + "' aria-expanded='false' data-toggle='collapse'><i class='" + (string.IsNullOrEmpty(m.Icono) ? "" : m.Icono) + "'></i>" + m.Nombre + " </a>";
                //    MenuHtml += "<ul id='Dropdown" + m.IdMenu + "' class='collapse list-unstyled'>";

                //    List<Menu> Opciones = Lista.Where(x => x.IdPadre == m.IdMenu).ToList();
                //    foreach(Menu op in Opciones)
                //    {
                //        MenuHtml += "<li><a href='@Url.Content(\"" + op.href + "\")'>" + op.Nombre + "</a></li>";
                //    }

                //    MenuHtml += "</ul>";
                //    MenuHtml += "</li>";
                //}
                return MenuHtml;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        public List<MenuUsuario> GetAllByIdUsuario(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<MenuUsuario> Lista = (from mu in context.MenuUsuarios.Where(x => x.IdUsuario == IdUsuario)
                                           join me in context.Menu on mu.IdMenu equals me.IdMenu
                                           select new MenuUsuario()
                                           {
                                               IdMenuUsuario = mu.IdMenuUsuario,
                                               IdMenu = mu.IdMenu,
                                               IdUsuario = mu.IdUsuario,
                                               Menu = me
                                           }).OrderBy(x => x.Menu.Codigo).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        public List<Menu> GetNotAllByIdUsuario(int IdUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                List<Menu> Lista = (from me in context.Menu
                                    join mu in context.MenuUsuarios.Where(x => x.IdUsuario == IdUsuario) on me.IdMenu equals mu.IdMenu into Joined
                                    from j in Joined.DefaultIfEmpty()
                                    where j == null
                                    select new Menu()
                                    {
                                        IdMenu = me.IdMenu,
                                        Codigo = me.Codigo,
                                        Nombre = me.Nombre,
                                        Descripcion = me.Descripcion,
                                        CodPadre = me.CodPadre,
                                    }).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("GetNotAllByIdUsuario", ex.Message, null);
                throw;
            }
        }

        public void Create(MenuUsuario entity)
        {
            try
            {
                BaseContext context = new BaseContext();
                using(var tran = context.Database.BeginTransaction())
                {
                    context.MenuUsuarios.Add(entity);
                    context.SaveChanges();
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("MenuUsuarioCreate", ex.Message, null);
                throw;
            }
        }

        public void Delete(int IdMenuUsuario)
        {
            try
            {
                BaseContext context = new BaseContext();
                MenuUsuario entity = context.MenuUsuarios.Find(IdMenuUsuario);
                context.MenuUsuarios.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErroresBusiness.Create("MenuUsuarioDelete", ex.Message, null);
                throw;
            }
        }
    }
}
