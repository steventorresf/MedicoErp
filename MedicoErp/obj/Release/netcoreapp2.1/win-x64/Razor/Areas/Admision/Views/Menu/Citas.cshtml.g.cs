#pragma checksum "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\Citas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dd4ad1ea9fbf182c3c5ec789946ab5fa2f5d713"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admision_Views_Menu_Citas), @"mvc.1.0.view", @"/Areas/Admision/Views/Menu/Citas.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admision/Views/Menu/Citas.cshtml", typeof(AspNetCore.Areas_Admision_Views_Menu_Citas))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dd4ad1ea9fbf182c3c5ec789946ab5fa2f5d713", @"/Areas/Admision/Views/Menu/Citas.cshtml")]
    public class Areas_Admision_Views_Menu_Citas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/master/controllers/admision/cita.controller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Repositorios\MedicoErp_\MedicoErp\Areas\Admision\Views\Menu\Citas.cshtml"
  
    ViewData["Title"] = "Citas";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(90, 28204, true);
            WriteLiteral(@"
<style>
    .fontsize-10 {
        max-height: 250px;
    }
</style>

<div id=""RowPrincipal"" class=""row"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header d-flex align-items-center"">
                        <div class=""col-12 text-right"">
                            <i ng-click=""vm.nuevoPac()"" class=""btn-link text-right"">Nuevo Paciente</i>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <form>
                            <div class=""form-group row"">
                                <div class=""col-12 col-md-7"">
                                    <label>Tipo Documento:</label>
                                    <ui-select ng-model=""vm.entity.tipoIden""
                                               form=""formApp""
                                               theme=""bootstrap");
            WriteLiteral(@"""
                                               tabindex=""7""
                                               required
                                               on-select=""vm.getPacienteByIden()"">
                                        <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.descripcion }}</ui-select-match>
                                        <ui-select-choices repeat=""item.codValor as item in vm.listTiposIden | filter: $select.search"">
                                            <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                                </div>
                                <div class=""col-12 col-md-5"">
                                    <label>N&uacute;mero Documento:</label>
                                    <input ng-model=""vm.entity.numIden"" type=""text"" class=""form-control"" ng-blur=""vm.getPacienteByIden");
            WriteLiteral(@"()"" required />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class=""row mt-2"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>{{vm.entityPac.nombrePaciente}}</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <ui-select ng-model=""vm.entity.idConvenio""
                                           form=""formApp""
                                           theme=""bootstrap""
                                           tabindex=""7""
                                           required
                                           on-select=""vm.onChangeConvenio($item, $model)"">
                              ");
            WriteLiteral(@"      <ui-select-match placeholder=""Seleccione un convenio..."">{{ $select.selected.nombreConvenio }}</ui-select-match>
                                    <ui-select-choices repeat=""item.idConvenio as item in vm.listConvenios | filter: $select.search"">
                                        <div ng-bind-html=""item.nombreConvenio | highlight: $select.search""></div>
                                    </ui-select-choices>
                                </ui-select>
                            </div>
                        </div>
                        <div class=""row mt-2"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptions"" ui-grid-selection ui-grid-edit ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <div class=""row"">
                            <div ");
            WriteLiteral(@"class=""col-12 col-md-7"">
                                <button class=""btn btn-primary"" ng-click=""vm.asignarCit()"" ng-disabled=""vm.gridApi.selection.getSelectedRows().length > 0""><i class=""fa fa-plus""></i> Asignar</button>
                                <button class=""btn btn-success"" ng-click=""vm.trasladarCit()"" ng-disabled=""vm.gridApi.selection.getSelectedRows().length === 0""><i class=""fa fa-sign-in""></i> Trasladar</button>
                                <button class=""btn btn-warning"" ng-click=""vm.facturarCit()"" ng-disabled=""vm.gridApi.selection.getSelectedRows().length === 0""><i class=""fa fa-check""></i> Facturar</button>
                            </div>
                            <div class=""col-12 col-md-5 text-right"">
                                <button class=""btn btn-danger"" ng-click=""vm.eliminarCit()"" ng-disabled=""vm.gridApi.selection.getSelectedRows().length === 0""><i class=""fa fa-times""></i> Cancelar</button>
                            </div>
                        </div>
      ");
            WriteLiteral(@"              </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div id=""RowDatosCita"" class=""row"" hidden=""hidden"">
    <div class=""col-12 offset-md-1 col-md-10"">
        <div class=""row"">
            <div class=""col-12 col-md-7"">
                <div class=""card"">
                    <div class=""card-body"">
                        <form id=""formApp"" name=""formApp"" novalidate=""novalidate"" class=""form-horizontal"">
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <label>Nombre Paciente:</label>
                                    <input type=""text"" class=""form-control"" ng-model=""vm.entityPac.nombrePaciente"" onkeydown=""return false"" />
                                </div>
                            </div>
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <label>Iden");
            WriteLiteral(@"tificaci&oacute;n:</label>
                                    <input type=""text"" class=""form-control"" ng-model=""vm.entityPac.identificacion"" onkeydown=""return false"" />
                                </div>
                            </div>
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <label>Convenio:</label>
                                    <input type=""text"" class=""form-control"" ng-model=""vm.entityCon.nombreConvenio"" onkeydown=""return false"" />
                                </div>
                            </div>
                            <div class=""form-group row"" ng-if=""vm.asign"">
                                <div class=""col-12"">
                                    <label>Servicio:<label class=""red"">*</label></label>
                                    <ui-select ng-model=""vm.entityCit.idServicio""
                                               form=""formApp""
                 ");
            WriteLiteral(@"                              theme=""bootstrap""
                                               tabindex=""7""
                                               required
                                               on-select=""vm.onChangeServicio($item, $model)"">
                                        <ui-select-match placeholder=""Seleccione un servicio..."">{{ $select.selected.servicio.nombreServicio }}</ui-select-match>
                                        <ui-select-choices repeat=""item.idServicio as item in vm.listServicios | filter: $select.search"">
                                            <div ng-bind-html=""item.servicio.nombreServicio | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                                </div>
                            </div>
                            <div class=""form-group row"" ng-if=""vm.trasl"">
                                <div class=""col-12"">
             ");
            WriteLiteral(@"                       <label>Servicio:</label>
                                    <input type=""text"" class=""form-control"" ng-model=""vm.entityCit.nombreServicio"" onkeydown=""return false"" />
                                </div>
                            </div>
                            <div class=""form-group row"" ng-if=""vm.trasl"">
                                <div class=""col-12"">
                                    <label>M&eacute;dico:</label>
                                    <input type=""text"" class=""form-control"" ng-model=""vm.entityCit.nombreMedico"" onkeydown=""return false"" />
                                </div>
                            </div>
                            <div class=""form-group row"" ng-if=""vm.trasl"">
                                <div class=""col-12"">
                                    <label>Fecha Hora:</label>
                                    <input type=""text"" class=""form-control"" ng-model=""vm.entityCit.sFechaHora"" onkeydown=""return false"" />
        ");
            WriteLiteral(@"                        </div>
                            </div>
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <button class=""btn btn-default"" ng-click=""vm.cancelar()"">Regresar</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class=""col-12 col-md-5"">
                <div class=""card"">
                    <div class=""card-body"">
                        <form class=""form-horizontal"" novalidate=""novalidate"">
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <label>M&eacute;dico:</label>
                                    <ui-select ng-model=""vm.entityCit.idMedico""
                                               form=""formApp""
                        ");
            WriteLiteral(@"                       theme=""bootstrap""
                                               tabindex=""7""
                                               required
                                               on-select=""vm.onChangeMedico($item, $model)"">
                                        <ui-select-match placeholder=""Seleccione un médico..."">{{ $select.selected.nombreCompleto }}</ui-select-match>
                                        <ui-select-choices repeat=""item.idUsuario as item in vm.listMedicos | filter: $select.search"">
                                            <div ng-bind-html=""item.nombreCompleto | highlight: $select.search""></div>
                                        </ui-select-choices>
                                    </ui-select>
                                </div>
                            </div>
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <label>Fecha de la Cita:<l");
            WriteLiteral(@"abel class=""red"">*</label></label>
                                    <input id=""TxtFechaCita"" type=""text"" form=""formApp"" ng-model=""vm.entityCit.fecha"" required class=""form-control"" />
                                </div>
                            </div>
                            <div class=""form-group row"">
                                <div class=""col-12"">
                                    <div class=""fontsize-10"" ui-grid=""vm.gridOptionsHor"" ui-grid-resize-columns ui-grid-auto-resize></div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<div id=""RowDatosPac"" class=""row ml-5 mr-5"" hidden=""hidden"">
    <div class=""col-12"">
        <div class=""card"">
            <div ng-show=""!vm.modifyPac"" class=""card-header d-flex align-items-center"">
                <h4>Nuevo Paciente</h4>
            </div>
            <div clas");
            WriteLiteral(@"s=""card-body"">
                <form id=""formAppPac"" name=""formAppPac"" novalidate=""novalidate"" class=""form-horizontal"">
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-7"">
                            <label>Tipo Identificaci&oacute;n:<label class=""red"">*</label></label>
                            <ui-select ng-model=""vm.entityPac.tipoIden""
                                       form=""formAppPac""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required>
                                <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.descripcion }}</ui-select-match>
                                <ui-select-choices repeat=""item.codValor as item in vm.listTiposIden | filter: $select.search"">
                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                </ui");
            WriteLiteral(@"-select-choices>
                            </ui-select>
                        </div>
                        <div class=""col-12 col-md-5"">
                            <label>N&uacute;mero Identificaci&oacute;n:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.numIden"" type=""text"" form=""formAppPac"" class=""form-control"" required />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-3"">
                            <label>Primer Nombre:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.primerNombre"" type=""text"" form=""formAppPac"" class=""form-control"" required />
                        </div>
                        <div class=""col-12 col-md-3"">
                            <label>Segundo Nombre:</label>
                            <input ng-model=""vm.entityPac.segundoNombre"" type=""text"" form=""formAppPac""");
            WriteLiteral(@" class=""form-control"" />
                        </div>
                        <div class=""col-12 col-md-3"">
                            <label>Primer Apellido:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.primerApellido"" type=""text"" form=""formAppPac"" class=""form-control"" required />
                        </div>
                        <div class=""col-12 col-md-3"">
                            <label>Segundo Apellido:</label>
                            <input ng-model=""vm.entityPac.segundoApellido"" type=""text"" form=""formAppPac"" class=""form-control"" />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-3"">
                            <label>Sexo:<label class=""red"">*</label></label>
                            <select ng-model=""vm.entityPac.codSexo"" form=""formAppPac"" class=""form-control"" required>
                                <option ng-r");
            WriteLiteral(@"epeat=""item in vm.listSexos"" value=""{{ item.codigo }}"">{{ item.descripcion }}</option>
                            </select>
                        </div>
                        <div class=""col-12 col-md-3"">
                            <label>Fecha Nacimiento:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.fechaNacimiento"" form=""formAppPac"" type=""date"" class=""form-control"" required />
                        </div>
                        <div class=""col-12 col-md-3"">
                            <label>Departamento:<label class=""red"">*</label></label>
                            <ui-select ng-model=""vm.entityPac.codDepartamento""
                                       form=""formAppPac""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required
                                       on-select=""vm.getMunicipios()"">
                                <ui-se");
            WriteLiteral(@"lect-match placeholder=""Seleccione..."">{{ $select.selected.nomDepartamento }}</ui-select-match>
                                <ui-select-choices repeat=""item.codDepartamento as item in vm.listDepartamentos | filter: $select.search"">
                                    <div ng-bind-html=""item.nomDepartamento | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                        <div class=""col-12 col-md-3"">
                            <label>Municipio:<label class=""red"">*</label></label>
                            <ui-select ng-model=""vm.entityPac.codMunicipio""
                                       form=""formAppPac""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required>
                                <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.nomMunicipio }}");
            WriteLiteral(@"</ui-select-match>
                                <ui-select-choices repeat=""item.codMunicipio as item in vm.listMunicipios | filter: $select.search"">
                                    <div ng-bind-html=""item.nomMunicipio | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-7"">
                            <label>Direcci&oacute;n:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.direccion"" form=""formAppPac"" type=""text"" class=""form-control"" required />
                        </div>
                        <div class=""col-12 col-md-5"">
                            <label>Tel&eacute;fono:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.telefono"" form=""formAppPac"" type=""text"" cl");
            WriteLiteral(@"ass=""form-control"" required />
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-4"">
                            <label>Barrio:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.barrio"" form=""formAppPac"" type=""text"" class=""form-control"" required />
                        </div>
                        <div class=""col-12 col-md-4"">
                            <label>Ocupaci&oacute;n:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.ocupacion"" form=""formAppPac"" type=""text"" class=""form-control"" required />
                        </div>
                        <div class=""col-12 col-md-4"">
                            <label>Estado Civil:<label class=""red"">*</label></label>
                            <ui-select ng-model=""vm.entityPac.codEstadoCivil""
                                       form=""formAppPac");
            WriteLiteral(@"""
                                       theme=""bootstrap""
                                       tabindex=""7""
                                       required>
                                <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.descripcion }}</ui-select-match>
                                <ui-select-choices repeat=""item.codValor as item in vm.listEstadosCivil | filter: $select.search"">
                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <div class=""col-12 col-md-4"">
                            <label>Zona:<label class=""red"">*</label></label>
                            <ui-select ng-model=""vm.entityPac.codZona""
                                       form=""formAppPac""
                   ");
            WriteLiteral(@"                    theme=""bootstrap""
                                       tabindex=""7""
                                       required>
                                <ui-select-match placeholder=""Seleccione..."">{{ $select.selected.descripcion }}</ui-select-match>
                                <ui-select-choices repeat=""item.codigo as item in vm.listZonas | filter: $select.search"">
                                    <div ng-bind-html=""item.descripcion | highlight: $select.search""></div>
                                </ui-select-choices>
                            </ui-select>
                        </div>
                        <div class=""col-12 col-md-4"">
                            <label>Correo:<label class=""red"">*</label></label>
                            <input ng-model=""vm.entityPac.correo"" form=""formAppPac"" type=""text"" class=""form-control"" required />
                        </div>
                    </div>
                    <div class=""form-group row"">
                ");
            WriteLiteral(@"        <div class=""col-12"">
                            <button ng-click=""vm.guardarPac1()"" ng-show=""!vm.modifyPac"" ng-disabled=""formAppPac.$invalid"" class=""btn btn-primary"">Guardar</button>
                            <button ng-click=""vm.guardarPac2()"" ng-show=""vm.modifyPac"" ng-disabled=""formAppPac.$invalid"" class=""btn btn-primary"">Guardar y Continuar</button>
                            <button ng-click=""vm.cancelarPac()"" ng-show=""!vm.modifyPac"" class=""btn btn-default"">Cancelar</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

<style>
    #RowRecordatorio table {
        min-width: 100% !important;
        vertical-align: top;
    }

    #RowRecordatorio tr {
        border-bottom: 1px solid lightgray;
    }
</style>

<div id=""RowRecordatorio"" class=""row"" hidden=""hidden"">
    <div class=""col-12 offset-md-2 col-md-8"">
        <div class=""card"">
            <div class=""card-header"">
     ");
            WriteLiteral(@"           <h4 ng-if=""vm.asign || vm.trasl"">Recordatorio de la Cita</h4>
                <h4 ng-if=""vm.elimi"">¿Desea Eliminar la siguiente cita?</h4>
            </div>
            <div class=""card-body"">
                <table>
                    <tr>
                        <th width=""35%"">Paciente:</th>
                        <td>{{vm.entityPac.nombrePaciente}}</td>
                    </tr>
                    <tr>
                        <th>Documento Identidad:</th>
                        <td>{{vm.entityPac.identificacion}}</td>
                    </tr>
                    <tr>
                        <th>Convenio:</th>
                        <td>{{vm.entityCon.nombreConvenio}}</td>
                    </tr>
                    <tr>
                        <th>Servicio:</th>
                        <td>{{vm.entityCit.nombreServicio}}</td>
                    </tr>
                    <tr>
                        <th>M&eacute;dico:</th>
                        <td>{{vm.entityC");
            WriteLiteral(@"it.nombreMedico}}</td>
                    </tr>
                    <tr>
                        <th>Fecha:</th>
                        <td>{{vm.entityCit.fecha | date: 'dd/MM/yyyy'}}</td>
                    </tr>
                    <tr>
                        <th>Hora:</th>
                        <td>{{vm.entityCit.hora}}</td>
                    </tr>
                </table>
            </div>
            <div class=""card-footer"">
                <button class=""btn btn-primary"" ng-click=""vm.terminar()"" ng-if=""vm.asign || vm.trasl""><i class=""fa fa-refresh""></i> Terminar</button>
                <button class=""btn btn-success"" ng-click=""vm.imprimirCita()"" ng-if=""vm.asign || vm.trasl""><i class=""fa fa-print""></i> Imprimir</button>
                <button class=""btn btn-danger"" ng-click=""vm.elimiCita()"" ng-if=""vm.elimi""><i class=""fa fa-remove""></i> Cancelar Cita</button>
                <button class=""btn btn-default"" ng-click=""vm.cancelar2()"" ng-if=""vm.elimi""><i class=""fa fa-arrow-left""><");
            WriteLiteral(@"/i> Regresar</button>
            </div>
        </div>
    </div>
</div>


<div id=""RowFacturacion"" class=""row"" hidden=""hidden"">
    <div class=""col-12 offset-md-1 col-md-8"">
        <div class=""row"">
            <div class=""col-12 text-center"">
                <h4>{{vm.entityPac.nombrePaciente}}</h4>
            </div>
        </div>
        <div class=""row mt-2"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4>{{vm.entityCon.nombreConvenio}}</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12 col-md-7"">
                                <label>Nombre Acompañante:</label>
                                <input type=""text"" class=""form-control"" ng-model=""vm.entityFact.nombreAcomp"" />
                            </div>
                            <div class=""col-12 col-md-5"">
      ");
            WriteLiteral(@"                          <label>Tel&eacute;fono Acompañante:</label>
                                <input type=""text"" class=""form-control"" ng-model=""vm.entityFact.telefonoAcomp"" />
                            </div>
                        </div>
                        <div class=""row mt-5"">
                            <div class=""col-12"">
                                <div class=""fontsize-10"" ui-grid=""vm.gridOptionsFact"" ui-grid-resize-columns ui-grid-auto-resize></div>
                            </div>
                        </div>
                        <div class=""row mt-2"">
                            <div class=""col-12 text-right"">
                                <h4>$ {{vm.entityFact.valorTotal | number: 0}}</h4>
                            </div>
                        </div>
                    </div>
                    <div class=""card-footer text-right"">
                        <button class=""btn btn-default"" ng-click=""vm.factCitaCancelar()""><i class=""fa fa-arrow-left""></");
            WriteLiteral(@"i> Cancelar</button>
                        <button class=""btn btn-primary"" ng-click=""vm.factCita()""><i class=""fa fa-file-text""></i> Facturar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div id=""RowFacturacionPost"" class=""row"" hidden=""hidden"">
    <div class=""col-12 offset-md-1 col-md-8"">
        <div class=""row mt-2"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h4 class=""text-success"">Facturaci&oacute;n exitosa</h4>
                    </div>
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <h4>La facturaci&oacute;n del paciente {{vm.entityPac.nombrePaciente}} del convenio {{vm.entityCon.nombreConvenio}} ha sido registrada existosamente.</h4>
                                <br />
                             ");
            WriteLiteral(@"   <h4>¿Qu&eacute; desea hacer?</h4>
                            </div>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <button class=""btn btn-success"" ng-click=""vm.imprimirVolFact()""><i class=""fa fa-print""></i> Imprimir</button>
                        <button class=""btn btn-primary"" ng-click=""vm.terminar()""><i class=""fa fa-refresh""></i> Terminar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            BeginContext(28294, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c3e534c80de4bf8bbb14fb9914ab484", async() => {
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
