#pragma checksum "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\ActualizarHistoria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b01c696f360c54c0c5d3d67a61fe07c66f28cf44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_ActualizarHistoria), @"mvc.1.0.view", @"/Areas/HistoriaClinica/Views/Menu/ActualizarHistoria.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b01c696f360c54c0c5d3d67a61fe07c66f28cf44", @"/Areas/HistoriaClinica/Views/Menu/ActualizarHistoria.cshtml")]
    public class Areas_HistoriaClinica_Views_Menu_ActualizarHistoria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/historiaClinica/actualizarHistoria.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\ActualizarHistoria.cshtml"
  
    ViewData["Title"] = "ActualizarHistoria";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"" ng-show=""vm.gridVisible"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                                    <div class=""form-group row"">
                                        <div class=""col-12 col-md-5"">
                                            <label>Tipo Documento:</label>
                                            <ui-select ng-model=""vm.entity.tipoIden""
                                                       form=""formApp""
                                                       theme=""bootstrap""
                                                       tabindex=""7""
                                                       required
 ");
            WriteLiteral(@"                                                      on-select=""vm.getPacienteByIden()"">
                                                <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.descripcion }}</ui-select-match>
                                                <ui-select-choices repeat=""item.codValor as item in vm.listTiposIden | filter: $select.search"">
                                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                                </ui-select-choices>
                                            </ui-select>
                                        </div>
                                        <div class=""col-12 col-md-4"">
                                            <label>N&uacute;mero Documento:</label>
                                            <input ng-model=""vm.entity.numIden"" type=""text"" class=""form-control"" ng-blur=""vm.getPacienteByIden()"" required />
                         ");
            WriteLiteral(@"               </div>
                                        <div class=""col-12 col-md-3"">
                                            <br />
                                            <button class=""btn btn-primary"" ng-click=""vm.buscarEventos()"">Consultar</button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12 text-center"">
                <h4>{{vm.entityPac.nombrePaciente}}</h4>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>Eventos</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""r");
            WriteLiteral(@"ow"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptionsEve"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <button class=""btn btn-primary"" ng-click=""vm.nuevoEvento()"">Nuevo Evento</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""row"" ng-show=""vm.formVisible"">
    <div class=""col-12 offset-md-2 col-md-8"">
        <div class=""card"">
            <div class=""card-header"">
                <h4>{{vm.entityPac.nombrePaciente}}</h4>
            </div>
            <div class=""card-body"">
                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                    <div class=""form-group row"">
                  ");
            WriteLiteral(@"      <div class=""col-12 col-md-4"">
                            <label>Tipo Identificaci&oacute;n:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityPac.tipoIden"" onkeydown=""return false"" />
                        </div>
                        <div class=""col-12 col-md-8"">
                            <label>N&uacute;mero Identificaci&oacute;n:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityPac.numIden"" onkeydown=""return false"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Paciente:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityPac.nombrePaciente"" onkeydown=""return false"" />
                        </div>
                    </div>
                    <div class=""form-");
            WriteLiteral(@"group row"">
                        <div class=""col-12"">
                            <label>Convenio:</label>
                            <ui-select ng-model=""vm.entity.idConvenio""
                                       form=""formApp""
                                       theme=""bootstrap""
                                       required>
                                <ui-select-match placeholder=""Seleccione un convenio..."">{{ $select.selected.nombreConvenio }}</ui-select-match>
                                <ui-select-choices repeat=""item.idConvenio as item in vm.listConvenios | filter: $select.search"">
                                    <div ng-bind-html=""item.nombreConvenio | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                    </div>
                    <button class=""btn btn-primary"" ng-click=""vm.generarEvento()"" ng-disabled=""formApp.$invalid"">Generar Evento</bu");
            WriteLiteral("tton>\r\n                </form>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b01c696f360c54c0c5d3d67a61fe07c66f28cf4410038", async() => {
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
