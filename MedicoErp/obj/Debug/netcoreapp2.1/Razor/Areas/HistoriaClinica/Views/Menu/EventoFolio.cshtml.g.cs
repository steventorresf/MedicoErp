#pragma checksum "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFolio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3007f570c00293cd5d6ae22379897af05fdf68ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_EventoFolio), @"mvc.1.0.view", @"/Areas/HistoriaClinica/Views/Menu/EventoFolio.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/HistoriaClinica/Views/Menu/EventoFolio.cshtml", typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_EventoFolio))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3007f570c00293cd5d6ae22379897af05fdf68ab", @"/Areas/HistoriaClinica/Views/Menu/EventoFolio.cshtml")]
    public class Areas_HistoriaClinica_Views_Menu_EventoFolio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/historiaClinica/evento.controller.folio.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFolio.cshtml"
  
    ViewData["Title"] = "Folio";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(90, 310, true);
            WriteLiteral(@"
<style>
    .fontsize-10 {
        max-height: 150px;
        font-size: 0.8em;
    }

    .bg-header {
        background-color: transparent;
    }

    .cursorPointer {
        cursor: pointer;
    }

    .tabla {
        font-size: 0.85em;
    }
</style>

<script>
    var IdEvento = '");
            EndContext();
            BeginContext(401, 16, false);
#line 27 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFolio.cshtml"
               Write(ViewBag.IdEvento);

#line default
#line hidden
            EndContext();
            BeginContext(417, 23, true);
            WriteLiteral("\';\r\n    var IdFolio = \'");
            EndContext();
            BeginContext(441, 15, false);
#line 28 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFolio.cshtml"
              Write(ViewBag.IdFolio);

#line default
#line hidden
            EndContext();
            BeginContext(456, 6167, true);
            WriteLiteral(@"';
</script>


<div class=""row"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""row"">
            <div class=""col-12"">
                <button class=""btn btn-default"" ng-click=""vm.regresarEvento()"">Regresar al Evento</button>
            </div>
            <div class=""col-12 mt-3"">
                <div class=""card"">
                    <div class=""card-header text-center"">
                        <h4>Datos Del Paciente</h4>
                    </div>
                    <div class=""card-body"">
                        <table class=""tabla nohover"">
                            <thead>
                                <tr>
                                    <th>No. Evento:</th>
                                    <td colspan=""3"">{{vm.entity.noEvento}}</td>
                                    <th>Fecha:</th>
                                    <td>{{vm.entity.sFechaEvento}}</td>
                                </tr>
                                <tr>
                 ");
            WriteLiteral(@"                   <th>Paciente:</th>
                                    <td colspan=""3"">{{vm.entity.paciente.nombrePaciente}}</td>
                                    <th>Doc. Identidad:</th>
                                    <td>{{vm.entity.paciente.tipoIden + ' ' + vm.entity.paciente.numIden}}</td>
                                </tr>
                                <tr>
                                    <th>Fecha Nac.:</th>
                                    <td>{{vm.entity.sFechaNacimiento}}</td>
                                    <th>Sexo:</th>
                                    <td>{{vm.entity.paciente.codSexo}}</td>
                                    <th>Ocupaci&oacute;n:</th>
                                    <td>{{vm.entity.paciente.ocupacion}}</td>
                                </tr>
                                <tr>
                                    <th>Direcci&oacute;n:</th>
                                    <td colspan=""3"">{{vm.entity.paciente.direccion}}</td>");
            WriteLiteral(@"
                                    <th>Tel&eacute;fonos:</th>
                                    <td>{{vm.entity.paciente.telefono}}</td>
                                </tr>
                                <tr>
                                    <th>Barrio:</th>
                                    <td>{{vm.entity.paciente.barrio}}</td>
                                    <th>Estado Civil:</th>
                                    <td>{{vm.entity.estadoCivil}}</td>
                                    <th>Correo:</th>
                                    <td>{{vm.entity.paciente.correo}}</td>
                                </tr>
                                <tr>
                                    <th>EPS:</th>
                                    <td colspan=""3"">{{vm.entity.convenio.nombreEps}}</td>
                                    <th>Tipo Usuario:</th>
                                    <td>{{vm.entity.tipoUsuario}}</td>
                                </tr>
                     ");
            WriteLiteral(@"           <tr>
                                    <th>Convenio:</th>
                                    <td colspan=""5"">{{vm.entity.convenio.nombreConvenio}}</td>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row mb-3"">
            <div class=""col-12 text-center"">
                <h1>{{vm.entityFol.formato.nombreFormato}}</h1>
            </div>
        </div>
        <div class=""row mt-3"" ng-repeat=""a in vm.entityFol.listaAreas"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"" ng-if=""a.visible"">
                        <h4>{{a.nombreArea}}</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row mb-3"" ng-repeat=""p in a.listaPreguntas"">
                            <div class=""col-12"">
             ");
            WriteLiteral(@"                   <label>{{p.nombrePregunta}}:</label>
                                <input ng-if=""p.tipoDato === 'NU'"" type=""number"" class=""form-control"" ng-model=""p.valor"" />
                                <input ng-if=""p.tipoDato === 'TE'"" type=""text"" class=""form-control"" ng-model=""p.valor"" />
                                <textarea ng-if=""p.tipoDato === 'TL'"" rows=""5"" class=""form-control"" ng-model=""p.valor"" ng-blur=""vm.onChangeRespuesta(p, $model, p)""></textarea>
                                <textarea ng-if=""p.tipoDato === 'TX'"" rows=""10"" class=""form-control"" ng-model=""p.valor"" ng-blur=""vm.onChangeRespuesta(p, $model, p)""></textarea>
                                <input ng-if=""p.tipoDato === 'FE'"" type=""date"" class=""form-control"" ng-model=""p.valor"" />
                                <ui-select ng-model=""p.valor""
                                           ng-if=""p.tipoDato === 'CO'""
                                           theme=""bootstrap""
                                           o");
            WriteLiteral(@"n-select=""vm.onChangeRespuesta($item, $model, p)"">
                                    <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.nombreRespuesta }}</ui-select-match>
                                    <ui-select-choices repeat=""item.codigo as item in p.listaTipoRespuesta | filter: $select.search"">
                                        <div ng-bind-html=""item.nombreRespuesta | highlight: $select.search""></div>
                                    </ui-select-choices>
                                </ui-select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class=""row mb-3"">
            <div class=""col-12"">
                <button class=""btn btn-success"" ng-click=""vm.imprimirFolio()"">Imprimir Folio</button>
                <button class=""btn btn-primary"" ng-click=""vm.guardarFolio()"">Guardar Folio</button>
            </div>
        </div>");
            WriteLiteral("\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(6623, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b95e1179a4d14d9f8abe73e0f4b16f97", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
