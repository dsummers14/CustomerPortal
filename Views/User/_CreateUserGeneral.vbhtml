@ModelType b2c_ms_graph.UserModel
@imports System.Security.Claims


@Code

    Dim gcustomerNumber = ClaimsPrincipal.Current.Claims.Where(Function(w) w.Type = "extension_CustomerNumber").Select(Function(s) s.Value).FirstOrDefault()
    Dim gwebRole = ClaimsPrincipal.Current.Claims.Where(Function(w) w.Type = "extension_WebRole").Select(Function(s) s.Value).FirstOrDefault()
    Dim filterCustomer As Boolean = (gwebRole <> "1")
End Code


 @Using Html.BeginForm
    @<fieldset>

    @Html.HiddenFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_TenantId)
    @Html.HiddenFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_WebRole)
    <div Class="k-content">
        <Table>
            <tr>
                <td>Company:</td>
                <td>
                    @code
                        Html.Kendo().DropDownListFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId) _
                                                                                                                     .Name("companyDropDownList") _
                                                                                                                     .DataTextField("displayName") _
                                                                                                                     .DataValueField("id") _
                                                                                                                     .HtmlAttributes(New With {.style = "width:250px", .class = "form-control"}) _
                                                                                                                     .AutoBind(True) _
                                                                                                                     .Events(Function(e) e.Change("companyChange")) _
                        .DataSource(Sub(source)
                                        source.Read(Function(read)
                                                        read.Action("GetCompanies", "Company")
                                                    End Function) _
                                               .ServerFiltering(False)
                                    End Sub) _
                                .Render()
                    End code
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Email Address:</td>
                <td>@Html.EditorFor(Function(m) m.DisplayEmailName)</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Display Name:</td>
                <td>@Html.EditorFor(Function(m) m.DisplayName)</td>
                <td></td>
                <td></td>

            </tr>
            <tr>
                <td>Customer:</td>
                <td>
                    @code
                        Html.Kendo().DropDownListFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber) _
                                                                     .Name("customerDropDownList") _
                                                                     .DataTextField("displayName") _
                                                                     .DataValueField("number") _
                                                                     .HtmlAttributes(New With {.style = "width:250px", .class = "form-control"}) _
                                                                     .AutoBind(True) _
                                                                     .DataSource(Sub(source)
                                                                                     source.Read(Function(read)
                                                                                                     read.Action("GetCustomers", "Customer").Data("getCompanyId")
                                                                                                 End Function) _
                                                                                            .ServerFiltering(False)
                                                                                 End Sub) _
                                                                     .Render()
                    End code
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>@Html.EditorFor(Function(m) m.newPassword)</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Confirm Password:</td>
                <td>@Html.EditorFor(Function(m) m.confirmPassword)</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Force Password Change Next Login:</td>
                <td>@Html.CheckBoxFor(Function(m) m.forcePasswordChange)</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Account Enabled:</td>
                <td>@Html.CheckBoxFor(Function(m) m.DisplayAccountEnabled)</td>
                <td></td>
                <td></td>
            </tr>
        </Table>
    </div>
    <p>
        @Html.Kendo().Button().Content("Update").Name("General")
        @Html.Kendo().Button().Content("Exit").Name("Cancel").HtmlAttributes(New With {.onClick = "backtoIndex();return false;"})
    </p>
</fieldset>
                                End Using


    <script type="text/javascript">
     function backtoIndex() {
        window.location.href = '@Url.Action("Index", "User")';
        }

        function getCompanyId() {
          
            return {CompanyId: $('#companyDropDownList').val() };
        }

        function companyChange(e) {
           
            $('#customerDropDownList').data('kendoDropDownList').dataSource.read();
        }
    </script>