#pragma checksum "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\ConsAgenda.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0775b4773a52336b86207740ad22d4cd8578260f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admision_Views_Menu_ConsAgenda), @"mvc.1.0.view", @"/Areas/Admision/Views/Menu/ConsAgenda.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admision/Views/Menu/ConsAgenda.cshtml", typeof(AspNetCore.Areas_Admision_Views_Menu_ConsAgenda))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0775b4773a52336b86207740ad22d4cd8578260f", @"/Areas/Admision/Views/Menu/ConsAgenda.cshtml")]
    public class Areas_Admision_Views_Menu_ConsAgenda : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/js/serviciosAjax.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/admision/consultarAg.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\ConsAgenda.cshtml"
  
    ViewData["Title"] = "Cons. Agenda";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(97, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(99, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d18b469cd0a94309a4872e435faa3d5b", async() => {
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
            BeginContext(151, 3145, true);
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-body"">
                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <label>M&eacute;dico:</label>
                            <ui-select ng-model=""vm.entity.idMedico""
                                       form=""formApp""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required
                                       on-select=""vm.onChangeMedico($item, $model)"">
                                <ui-select-match placeholder=""Seleccione un medico..."">{{ $select.selected.nombreCompleto }}</ui-select-match>
                                <ui-select-choices repeat=""item.idUsuario as item in vm.listMedicos | filter: $select.");
            WriteLiteral(@"search"">
                                    <div ng-bind-html=""item.nombreCompleto | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-6"">
                            <label>Fecha Inicio:</label>
                            <input type=""date"" class=""form-control"" form=""formApp"" ng-model=""vm.entity.fechaInicio"" required />
                        </div>
                        <div class=""col-12 col-md-6"">
                            <label>Fecha Fin:</label>
                            <input type=""date"" class=""form-control"" form=""formApp"" ng-model=""vm.entity.fechaFin"" required />
                        </div>
                    </div>
                </form>
            </div>
            <div class=""card-footer"">
                <div class=""row"">
       ");
            WriteLiteral(@"             <div class=""col-12"">
                        <button class=""btn btn-primary"" ng-click=""vm.consultarAg()"" ng-disabled=""formApp.$invalid"">Consultar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""fontsize-10"" ui-grid=""vm.gridOptions"" ui-grid-resize-columns ui-grid-auto-resize></div>
                    </div>
                </div>
            </div>
            <div class=""card-footer"">
                <div class=""row"">
                    <div class=""col-12"">
                        <button class=""btn btn-success"" ng-click=""vm.descargarExcel()"" ng-disabled=""vm.gridOptions.data.length === 0""><i class=""fa fa-file-excel-o""></i> Excel</button>
                    </div>
         ");
            WriteLiteral("       </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3296, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf0794abca264d53a2718253c658a0a6", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
