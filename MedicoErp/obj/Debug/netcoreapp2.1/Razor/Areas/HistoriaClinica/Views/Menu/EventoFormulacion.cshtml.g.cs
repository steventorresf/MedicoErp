#pragma checksum "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFormulacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bccdbe40ac60f48bf8be499db51c55cd44309815"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_EventoFormulacion), @"mvc.1.0.view", @"/Areas/HistoriaClinica/Views/Menu/EventoFormulacion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/HistoriaClinica/Views/Menu/EventoFormulacion.cshtml", typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_EventoFormulacion))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bccdbe40ac60f48bf8be499db51c55cd44309815", @"/Areas/HistoriaClinica/Views/Menu/EventoFormulacion.cshtml")]
    public class Areas_HistoriaClinica_Views_Menu_EventoFormulacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/historiaClinica/evento.controller.formulacion.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFormulacion.cshtml"
  
    ViewData["Title"] = "Evento - Formulacion";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(105, 6299, true);
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
</style>

<div class=""row"" ng-show=""vm.gridVisible"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-header text-center"">
                <h4>Historia Clinica #{{vm.entity.noEvento}}</h4>
            </div>
            <div class=""card-body"">
                <table class=""tabla nohover"">
                    <thead>
                        <tr>
                            <th>Paciente:</th>
                            <td>{{vm.entity.paciente.nombrePaciente + ' - ' + vm.entity.tipoIden + ' ' + vm.entity.numIden}}</td>
                            <th>Sexo:</th>
                            <td>{{vm.entity.paciente.codSexo}}</td>
                        </tr>
                        <tr>
                            <th>Convenio:");
            WriteLiteral(@"</th>
                            <td>{{vm.entity.convenio.nombreConvenio}}</td>
                            <th>Fecha Nac:</th>
                            <td>{{vm.entity.paciente.sFechaNacimiento}}</td>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</div>
<hr ng-show=""vm.gridVisible"" />
<div class=""row"" ng-show=""vm.gridVisible"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-header text-right"">
                <button class=""btn btn-sm btn-primary"" ng-click=""vm.agregarMed()"">Agregar</button>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""fontsize-10"" ui-grid=""vm.gridOptionsFor"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                    </div>
                </div>
                <div cl");
            WriteLiteral(@"ass=""row mt-3"">
                    <div class=""col-12 col-md-4"">
                        <label>Tiempo Evoluci&oacute;n:</label>
                        <input type=""text"" class=""form-control"" ng-model=""vm.entityFor.tiempoEvo"" />
                    </div>
                    <div class=""col-12 col-md-4"">
                        <label>Pr&oacute;ximo Control:</label>
                        <input type=""text"" class=""form-control"" ng-model=""vm.entityFor.proxControl"" />
                    </div>
                </div>
                <div class=""row mt-3"">
                    <div class=""col-12"">
                        <label>Observaciones:</label>
                        <textarea rows=""3"" class=""form-control"" ng-model=""vm.entityFor.observaciones""></textarea>
                    </div>
                </div>
            </div>
            <div class=""card-footer"">
                <div class=""row"">
                    <div class=""col-12"">
                        <button class=""btn btn-pri");
            WriteLiteral(@"mary"" ng-click=""vm.guardar()"" ng-disabled=""vm.gridOptionsFor.data.length === 0"">Guardar</button>
                        <button class=""btn btn-default"" ng-click=""vm.regresar()"">Volver al evento</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"" ng-show=""vm.formVisible"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-body"">
                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Medicamento:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityForDet.medicamento"" required />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-8"">
");
            WriteLiteral(@"                            <label>V&iacute;a Admon:</label>
                            <ui-select ng-model=""vm.entityForDet.codViaAdmon""
                                       form=""formApp""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       on-select=""vm.onChangeViaAdmon($item, $model)""
                                       required>
                                <ui-select-match placeholder=""Seleccione una via admon..."">{{ $select.selected.descripcion }}</ui-select-match>
                                <ui-select-choices repeat=""item.codValor as item in vm.listViasAdmon | filter: $select.search"">
                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                        <div class=""col-12 col-md-4"">
              ");
            WriteLiteral(@"              <label>Cantidad:</label>
                            <input type=""number"" class=""form-control"" ng-blur=""vm.fnGuardarRespuesta(1, this.value, '')"" form=""formApp"" ng-model=""vm.entityForDet.cantidad"" required />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Posologia:</label>
                            <textarea class=""form-control"" rows=""3"" form=""formApp"" ng-model=""vm.entityForDet.posologia"" required></textarea>
                        </div>
                    </div>
                </form>
            </div>
            <div class=""card-footer"">
                <div class=""row"">
                    <div class=""col-12"">
                        <button class=""btn btn-primary"" ng-click=""vm.agregarMedicamento()"" ng-disabled=""formApp.$invalid"">Agregar</button>
                        <button class=""btn btn-default"" ng-click=""vm.cancelar()"">Canc");
            WriteLiteral("elar</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    var IdEvento = \'");
            EndContext();
            BeginContext(6405, 16, false);
#line 142 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoFormulacion.cshtml"
               Write(ViewBag.IdEvento);

#line default
#line hidden
            EndContext();
            BeginContext(6421, 17, true);
            WriteLiteral("\';\r\n</script>\r\n\r\n");
            EndContext();
            BeginContext(6438, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19de128fe1ff4de183895c4f041f6d3d", async() => {
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
