#pragma checksum "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\Convenios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30e9b64833a233c24ada7c3892a0c79ef95fa507"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admision_Views_Menu_Convenios), @"mvc.1.0.view", @"/Areas/Admision/Views/Menu/Convenios.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admision/Views/Menu/Convenios.cshtml", typeof(AspNetCore.Areas_Admision_Views_Menu_Convenios))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30e9b64833a233c24ada7c3892a0c79ef95fa507", @"/Areas/Admision/Views/Menu/Convenios.cshtml")]
    public class Areas_Admision_Views_Menu_Convenios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/admision/convenio.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\Convenios.cshtml"
  
    ViewData["Title"] = "Convenios";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(94, 6719, true);
            WriteLiteral(@"
<div class=""row"" ng-show=""!vm.modoTar && !vm.formVisible"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-header d-flex align-items-center"">
                <button class=""btn btn-primary"" ng-click=""vm.nuevo()""><i class=""fa fa-plus""></i> Nuevo</button>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <div class=""fontsize-10"" ui-grid=""vm.gridOptions"" ui-grid-resize-columns ui-grid-auto-resize></div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"" ng-show=""!vm.modoTar && vm.formVisible"">
    <div class=""col-12 offset-md-2 col-md-8"">
        <div class=""card"">
            <div class=""card-header d-flex align-items-center"">
                <h4 class="""">Datos del Convenio</h4>
            </div>
            <div class=""card-body"">
                <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizo");
            WriteLiteral(@"ntal"">
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-8"">
                            <label class=""form-control-label required"">Convenio:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entity.nombreConvenio"" type=""text"" class=""form-control"" required>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-8"">
                            <label class=""form-control-label required"">EPS:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entity.nombreEps"" type=""text"" class=""form-control"" required>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-4"">
                            <label class=""form-control-label required"">Tipo Usuario:<label class=""red"">*</label></label>
   ");
            WriteLiteral(@"                         <ui-select ng-model=""vm.entity.codTipoUsuario""
                                       form=""formApp""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required>
                                <ui-select-match placeholder=""Seleccione..."">{{$select.selected.descripcion}}</ui-select-match>
                                <ui-select-choices repeat=""item.codValor as item in vm.listTiposUsuario | filter: $select.search"">
                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                        <div class=""col-12 col-md-4"">
                            <label class=""form-control-label required"">Tipo Fact.:<label class=""red"">*</label></label>
                            <ui-select ng-model=""vm.entity.cod");
            WriteLiteral(@"TipoFact""
                                       form=""formApp""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required>
                                <ui-select-match placeholder=""Seleccione..."">{{$select.selected.descripcion}}</ui-select-match>
                                <ui-select-choices repeat=""item.codValor as item in vm.listTiposFact | filter: $select.search"">
                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12"">
                            <button ng-click=""vm.guardar()"" class=""btn btn-primary"" ng-show=""!vm.formModify"" ng-disabled=""formApp.$invalid""><i class=""fa fa-save""></i> Guardar</bu");
            WriteLiteral(@"tton>
                            <button ng-click=""vm.guardar()"" class=""btn btn-primary"" ng-show=""vm.formModify"" ng-disabled=""formApp.$invalid""><i class=""fa fa-refresh""></i> Actualizar</button>
                            <button ng-click=""vm.cancelar()"" class=""btn btn-secondary""><i class=""fa fa-close""></i> Cancelar</button>
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>
</div>
<div class=""row"" ng-show=""vm.modoTar &&  !vm.formVisibleTar"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""card"">
            <div class=""card-header d-flex align-items-center"">
                <h4>{{vm.entity.nombreConvenio}}</h4>
            </div>
            <div class=""card-body"">
                <div class=""form-group"">
                    <div class=""table-responsive"">
                        <div class=""fontsize-10"" ui-grid=""vm.gridOptionsTar"" ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>");
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""form-group"">
                    <button ng-click=""vm.regresarTar()"" class=""btn btn-default""><i class=""fa fa-arrow-left""></i> Regresar</button>
                    <button ng-click=""vm.nuevoTar()"" class=""btn btn-primary""><i class=""fa fa-plus""></i> Agregar</button>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"" ng-show=""vm.modoTar && vm.formVisibleTar"">
    <div class=""col-12 offset-md-1 col-md-8"">
        <div class=""card"">
            <div class=""card-header d-flex align-items-center"">
                <h4>{{vm.entity.nombreConvenio}}</h4>
            </div>
            <div class=""card-body"">
                <form id=""formAppSerCon"" name=""formAppSerCon"">
                    <div class=""form-group"">
                        <label>Seleccione Servicio(s):</label>
                        <div class=""fontsize-10"" style=""height:250px"" ui-grid=""vm.gridOptionsSerCon"" ui-grid");
            WriteLiteral(@"-selection ui-grid-resize-columns ui-grid-auto-resize></div>
                    </div>
                    <div class=""form-group"">
                        <button ng-click=""vm.guardarTar()"" type=""button"" class=""btn btn-primary"" ng-disabled=""vm.gridApiSerCon.selection.getSelectedRows().length === 0"">Aceptar y Agregar</button>
                        <button ng-click=""vm.cancelarTar()"" class=""btn btn-default""><i class=""fa fa-close""></i> Cancelar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            BeginContext(6813, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f6a67d5dd3e498cb6aa22dfba7ff928", async() => {
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
