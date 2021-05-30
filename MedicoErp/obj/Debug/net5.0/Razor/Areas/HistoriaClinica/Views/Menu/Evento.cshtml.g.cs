#pragma checksum "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\Evento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1aaa6a36edb96ff62d5edbfd7f859061c92c36cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HistoriaClinica_Views_Menu_Evento), @"mvc.1.0.view", @"/Areas/HistoriaClinica/Views/Menu/Evento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1aaa6a36edb96ff62d5edbfd7f859061c92c36cf", @"/Areas/HistoriaClinica/Views/Menu/Evento.cshtml")]
    public class Areas_HistoriaClinica_Views_Menu_Evento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/historiaClinica/evento.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\Evento.cshtml"
  
    ViewData["Title"] = "";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
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

    .tabla{
        font-size:0.85em;
    }
</style>

<div class=""row"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""row"">
            <div class=""col-12"">
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
");
            WriteLiteral(@"                                </tr>
                                <tr>
                                    <th>Paciente:</th>
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
                                    <th>Direcci&oacute;n:</");
            WriteLiteral(@"th>
                                    <td colspan=""3"">{{vm.entity.paciente.direccion}}</td>
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
                                    <t");
            WriteLiteral(@"d>{{vm.entity.tipoUsuario}}</td>
                                </tr>
                                <tr>
                                    <th>Convenio:</th>
                                    <td colspan=""5"">{{vm.entity.convenio.nombreConvenio}}</td>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12 col-md-7"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>Folios</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptionsFo"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
");
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-12 col-md-5"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>Formatos</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptionsForm"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>Diagnosticos</h4>
                    </div>
                    <div class=""card-body""");
            WriteLiteral(@">
                        <form id=""formDiag"" name=""formDiag"" novalidate=""novalidate"" class=""form-horizontal"">
                            <div class=""form-group row"">
                                <div class=""col-12 offset-md-1 col-md-10"">
                                    <label>Diagnostico Principal:<span>*</span> </label>
                                    <ui-select ng-model=""vm.entity.codDiagPal""
                                               form=""formDiag""
                                               theme=""bootstrap""
                                               required
                                               on-select=""vm.onChangeDiagPal($item, $model)"">
                                        <ui-select-match placeholder=""Seleccione un diagnostico..."">{{ $select.selected.nombreDiagnostico }}</ui-select-match>
                                        <ui-select-choices repeat=""item.codigo as item in vm.listDiagsPal track by $index""
                                         ");
            WriteLiteral(@"                  refresh=""vm.refreshDiagPal($select.search)""
                                                           refresh-delay=""0"">
                                            <div ng-bind-html=""item.nombreDiagnostico | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                                </div>
                            </div>
                            <hr />
                            <div class=""form-group row"">
                                <div class=""col-12 offset-md-1 col-md-10"">
                                    <label>Diagnostico Relacional 1:</label>
                                    <ui-select ng-model=""vm.entity.codDiagRel1""
                                               form=""formDiag""
                                               theme=""bootstrap""
                                               on-select=""vm.onChangeDiagRel1($item, $model)"">
                ");
            WriteLiteral(@"                        <ui-select-match placeholder=""Seleccione un diagnostico..."">{{ $select.selected.nombreDiagnostico }}</ui-select-match>
                                        <ui-select-choices repeat=""item.codigo as item in vm.listDiagsRel1 track by $index""
                                                           refresh=""vm.refreshDiagRel1($select.search)""
                                                           refresh-delay=""0"">
                                            <div ng-bind-html=""item.nombreDiagnostico | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                                </div>
                            </div>
                            <hr />
                            <div class=""form-group row"">
                                <div class=""col-12 offset-md-1 col-md-10"">
                                    <label>Diagnostico Relacional 2:</label>
            ");
            WriteLiteral(@"                        <ui-select ng-model=""vm.entity.codDiagRel2""
                                               form=""formDiag""
                                               theme=""bootstrap""
                                               on-select=""vm.onChangeDiagRel2($item, $model)"">
                                        <ui-select-match placeholder=""Seleccione un diagnostico..."">{{ $select.selected.nombreDiagnostico }}</ui-select-match>
                                        <ui-select-choices repeat=""item.codigo as item in vm.listDiagsRel2 track by $index""
                                                           refresh=""vm.refreshDiagRel2($select.search)""
                                                           refresh-delay=""0"">
                                            <div ng-bind-html=""item.nombreDiagnostico | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                         ");
            WriteLiteral(@"       </div>
                            </div>
                            <hr />
                            <div class=""form-group row"">
                                <div class=""col-12 offset-md-1 col-md-10"">
                                    <label>Diagnostico Relacional 3:</label>
                                    <ui-select ng-model=""vm.entity.codDiagRel3""
                                               form=""formDiag""
                                               theme=""bootstrap""
                                               on-select=""vm.onChangeDiagRel3($item, $model)"">
                                        <ui-select-match placeholder=""Seleccione un diagnostico..."">{{ $select.selected.nombreDiagnostico }}</ui-select-match>
                                        <ui-select-choices repeat=""item.codigo as item in vm.listDiagsRel3 track by $index""
                                                           refresh=""vm.refreshDiagRel3($select.search)""
                            ");
            WriteLiteral(@"                               refresh-delay=""0"">
                                            <div ng-bind-html=""item.nombreDiagnostico | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12 col-md-6"">
                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""row"">
                            <div class=""col-12 col-md-6"">
                                <h4>Formulaciones</h4>
                            </div>
                            <div class=""col-12 col-md-6 text-right"">
                                <button class=""btn btn-sm btn-primary"" ng-click=""vm.nuevaFormula()"">Nuevo</button>
        ");
            WriteLiteral(@"                    </div>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptionsFor"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-12 col-md-6"">
                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""row"">
                            <div class=""col-12 col-md-6"">
                                <h4>Ordenes</h4>
                            </div>
                            <div class=""col-12 col-md-6 text-right"">
                                <button class=""btn btn-sm btn-primary"" ng-click=""vm.nuevaOrden()"">Nuevo</bu");
            WriteLiteral(@"tton>
                            </div>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptionsOrd"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class=""row mb-3"">
            <div class=""col-12"">
                <button class=""btn btn-success"" ng-click=""vm.imprimirEvento()""><i class=""fa fa-print""></i> Imprimir Evento</button>
                <button class=""btn btn-warning"" ng-click=""vm.imprimirConsentimiento()""><i class=""fa fa-print""></i> Imprimir Consentimiento</button>
                <button class=""btn btn-primary"" ng-click=""vm.finalizarEvento()"" ng-disabled=""for");
            WriteLiteral("mApp1.$invalid || formDiag.$invalid\"><i class=\"fa fa-sign-out\"></i> Finalizar Evento</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    var IdEvento = \'");
#nullable restore
#line 255 "C:\Repositorios\MedicoErp\MedicoErp\Areas\HistoriaClinica\Views\Menu\Evento.cshtml"
               Write(ViewBag.IdEvento);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n</script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1aaa6a36edb96ff62d5edbfd7f859061c92c36cf17755", async() => {
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
