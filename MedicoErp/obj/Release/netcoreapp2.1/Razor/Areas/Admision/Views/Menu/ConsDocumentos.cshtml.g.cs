#pragma checksum "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\ConsDocumentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f5bc21c070a7e2ebb7106996b14007627b0f13b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admision_Views_Menu_ConsDocumentos), @"mvc.1.0.view", @"/Areas/Admision/Views/Menu/ConsDocumentos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admision/Views/Menu/ConsDocumentos.cshtml", typeof(AspNetCore.Areas_Admision_Views_Menu_ConsDocumentos))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f5bc21c070a7e2ebb7106996b14007627b0f13b", @"/Areas/Admision/Views/Menu/ConsDocumentos.cshtml")]
    public class Areas_Admision_Views_Menu_ConsDocumentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/admision/consultarDocs.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\ConsDocumentos.cshtml"
  
    ViewData["Title"] = "Consultar Documentos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(105, 4721, true);
            WriteLiteral(@"
<div id=""RowBusqueda"" class=""row mt-5"">
    <div class=""col-12 offset-lg-1 col-lg-10"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>B&uacute;squeda por documento</h4>
                    </div>
                    <div class=""card-body"">
                        <form id=""form1"" name=""form1"" novalidate=""novalidate"" class=""form-inline"">
                            <div class=""form-group"">
                                <select class=""form-control"" ng-model=""vm.entityBusq.tipoDoc"" required>
                                    <option value=""VS"">VS</option>
                                </select>
                            </div>
                            <div class=""form-group"">
                                <input type=""text"" class=""form-control"" placeholder=""Número documento"" ng-model=""vm.entityBusq.numDoc"" required>
                            </div>
          ");
            WriteLiteral(@"                  <button class=""btn btn-primary ml-2"" ng-click=""vm.consultarByDoc()"" ng-disabled=""form1.$invalid"">Buscar</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row mt-3"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>B&uacute;squeda por paciente</h4>
                    </div>
                    <div class=""card-body"">
                        <form id=""form2"" name=""form2"" novalidate=""novalidate"" class=""form-inline"">
                            <div class=""form-group"">
                                <ui-select ng-model=""vm.entityBusq.tipoDocPac""
                                           form=""form2""
                                           theme=""bootstrap""
                                           required>
                                    <ui-select-match placeholder=""Seleccione...");
            WriteLiteral(@""">{{ $select.selected.descripcion }}</ui-select-match>
                                    <ui-select-choices repeat=""item.codValor as item in vm.listTiposIden | filter: $select.search"" style=""width:350px !important"">
                                        <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                    </ui-select-choices>
                                </ui-select>
                            </div>
                            <div class=""form-group"">
                                <input type=""text"" class=""form-control"" placeholder=""Número documento"" ng-model=""vm.entityBusq.numDocPac"" required>
                            </div>
                            <button class=""btn btn-primary ml-2"" ng-click=""vm.consultarByPac()"" ng-disabled=""form2.$invalid"">Buscar</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div id=""RowPaciente"" class");
            WriteLiteral(@"=""row mt-3"" hidden=""hidden"">
    <div class=""col-12 offset-lg-1 col-lg-10"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <button class=""btn btn-default"" ng-click=""vm.regresar()"">Regresar</button>
                            </div>
                        </div>
                        <div class=""row mt-3"">
                            <div class=""col-12"">
                                <table class=""tabla nohover"">
                                    <tr>
                                        <td><b>Paciente:</b></td>
                                        <td>{{vm.entityPac.nombrePaciente}}</td>
                                        <td><b>Identificaci&oacute;n:</b></td>
                                        <td>{{vm.entityPac.tipoIden + ' ' + vm.entityPac.numIden}}</td>");
            WriteLiteral(@"
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row mt-2"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""fontsize-10"" ui-grid=""vm.gridOptions"" ui-grid-resize-columns ui-grid-auto-resize></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            BeginContext(4826, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc9cbe84df6e4368a55e12c2caff5a1f", async() => {
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
