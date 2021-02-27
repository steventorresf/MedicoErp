#pragma checksum "C:\Users\Steven Torres\Desktop\STEVEN\FUENTES\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoOrdenMedica.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fc04df806e113ee6c52f7d117541c0889572977"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_EventoOrdenMedica), @"mvc.1.0.view", @"/Areas/HistoriaClinica/Views/Menu/EventoOrdenMedica.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/HistoriaClinica/Views/Menu/EventoOrdenMedica.cshtml", typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_EventoOrdenMedica))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fc04df806e113ee6c52f7d117541c0889572977", @"/Areas/HistoriaClinica/Views/Menu/EventoOrdenMedica.cshtml")]
    public class Areas_HistoriaClinica_Views_Menu_EventoOrdenMedica : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/historiaClinica/evento.controller.ordenMedica.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Steven Torres\Desktop\STEVEN\FUENTES\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoOrdenMedica.cshtml"
  
    ViewData["Title"] = "Evento - OrdenMedica";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(105, 3670, true);
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

<div class=""row"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-body"">
                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <h4 class=""modal-title"">Evento # {{vm.entity.noEvento}} &nbsp;&nbsp;&nbsp;&nbsp; {{vm.entity.paciente.nombrePaciente}}</h4>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Servicio:</label>
                            <ui-select ng-model=""vm.entityOrdDet.idServicio""
                          ");
            WriteLiteral(@"             form=""formApp""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required
                                       on-select=""vm.onChangeServicio($item, $model)"">
                                <ui-select-match placeholder=""Seleccione servicio..."">{{ $select.selected.nombreServicio }}</ui-select-match>
                                <ui-select-choices repeat=""item.idServicio as item in vm.listServicios | filter: $select.search"">
                                    <div ng-bind-html=""item.nombreServicio | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-4"">
                            <label>Cantidad:</label>
                            <input type=""numbe");
            WriteLiteral(@"r"" class=""form-control"" form=""formApp"" ng-model=""vm.entityOrdDet.cantidad"" required />
                        </div>
                        <div class=""col-12 col-md-4"">
                            <br />
                            <button class=""btn btn-primary"" ng-click=""vm.agregarServicio()"" ng-disabled=""formApp.$invalid"">Agregar</button>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <div class=""fontsize-10"" ui-grid=""vm.gridOptionsOrd"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>Observaciones:</label>
                            <textarea rows=""3"" class=""form-control"" ng-model=""vm.entityOrd.observaciones""></textarea>
                   ");
            WriteLiteral(@"     </div>
                    </div>
                </form>
            </div>
            <div class=""card-footer"">
                <div class=""row"">
                    <div class=""col-12"">
                        <button class=""btn btn-primary"" ng-click=""vm.guardar()"" ng-disabled=""vm.gridOptionsOrd.data.length === 0"">Guardar</button>
                        <button class=""btn btn-default"" ng-click=""vm.regresar()"">Volver al evento</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    var IdEvento = '");
            EndContext();
            BeginContext(3776, 16, false);
#line 84 "C:\Users\Steven Torres\Desktop\STEVEN\FUENTES\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\EventoOrdenMedica.cshtml"
               Write(ViewBag.IdEvento);

#line default
#line hidden
            EndContext();
            BeginContext(3792, 17, true);
            WriteLiteral("\';\r\n</script>\r\n\r\n");
            EndContext();
            BeginContext(3809, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c084ebe4f82344d387af3cff83c351f4", async() => {
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