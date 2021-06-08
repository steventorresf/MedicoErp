#pragma checksum "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\Atender.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b28f8cdfca5909f2ba3c7994a82c13a2919ac5b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_Atender), @"mvc.1.0.view", @"/Areas/HistoriaClinica/Views/Menu/Atender.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b28f8cdfca5909f2ba3c7994a82c13a2919ac5b8", @"/Areas/HistoriaClinica/Views/Menu/Atender.cshtml")]
    public class Areas_HistoriaClinica_Views_Menu_Atender : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/historiaClinica/atender.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\Atender.cshtml"
  
    ViewData["Title"] = "Atender";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"" ng-show=""vm.gridVisible"">
    <div class=""col-12 pl-5 pr-5"">
        <div class=""card"">
            <div class=""card-header"">
                <div class=""row"">
                    <div class=""col-12 col-md-4"">
                        <input type=""date"" class=""form-control"" ng-model=""vm.entity.fecha"" ng-change=""vm.getAll()"" />
                    </div>
                    <div class=""col-12 col-md-4"">
                        <button class=""btn btn-primary"" ng-click=""vm.getAll()"" ng-disabled=""vm.entity.fecha === undefined"">Buscar</button>
                    </div>
                </div>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-12"">
                        <h4>{{vm.entity.sFecha}}</h4>
                    </div>
                </div>
                <div class=""row mt-3"">
                    <div class=""col-12"">
                        <div class=""fontsize-10"" ui-grid=""vm.gridOptions"" ui");
            WriteLiteral(@"-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                    </div>
                </div>
            </div>
            <div class=""card-footer"">
                <div class=""row"">
                    <div class=""col-12"">
                        <button class=""btn btn-primary"" ng-click=""vm.atenderCita()"" ng-disabled=""vm.gridApi.selection.getSelectedRows().length === 0"">Atender</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""row"" ng-show=""vm.formTarifa"">
    <div class=""col-12 offset-md-2 col-md-8"">
        <div class=""card"">
            <div class=""card-header"">
                <h4>Actualizar Tarifa</h4>
            </div>
            <div class=""card-body"">
                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-5"">
               ");
            WriteLiteral(@"             <label>Fecha Hora:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.sFecha"" required readonly=""readonly"" />
                        </div>
                        <div class=""col-12 col-md-7"">
                            <label>Identificaci&oacute;n:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.identificacion"" required readonly=""readonly"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Nombre Paciente:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.nombrePaciente"" required readonly=""readonly"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">");
            WriteLiteral(@"
                            <label>Convenio:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.nombreConvenio"" required readonly=""readonly"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Servicio:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.nombreServicio"" required readonly=""readonly"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-4"">
                            <label>Estado:</label>
                            <input type=""text"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.nombreEstado"" required readonly=""readonly"" />
                        </div>
                        <div class=""col-12 col-");
            WriteLiteral(@"md-4"">
                            <label>Tarifa:</label>
                            <input type=""number"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.tarifa"" required />
                        </div>
                        <div class=""col-12 col-md-4"">
                            <label>Descuento:</label>
                            <input type=""number"" class=""form-control"" form=""formApp"" ng-model=""vm.entityCit.descuento"" required />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <button class=""btn btn-primary"" ng-click=""vm.actuaizarTarifa()"">Actualizar</button>
                            <button class=""btn btn-default"" ng-click=""vm.regresar()"">Regresar</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b28f8cdfca5909f2ba3c7994a82c13a2919ac5b88732", async() => {
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
