@ModelType b2c_ms_graph.UserModel
@imports System.Security.Claims


@Code

    Dim gcustomerNumber = ClaimsPrincipal.Current.Claims.Where(Function(w) w.Type = "extension_CustomerNumber").Select(Function(s) s.Value).FirstOrDefault()
    Dim gwebRole = ClaimsPrincipal.Current.Claims.Where(Function(w) w.Type = "extension_WebRole").Select(Function(s) s.Value).FirstOrDefault()
    Dim filterCustomer As Boolean = (gwebRole <> "1")
End Code


 @Using Html.BeginForm
    @<fieldset>
 
    <div Class="k-content">
                <Table>
     <tr>
     <td> Tenant Id:</td>
                        <td>@Html.EditorFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_TenantId)</td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Company Id:</td>
                        <td>@Html.EditorFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId)</td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Email Address:</td>
                        <td>@Html.EditorFor(Function(m) m.DisplayEmailName)</td>
                        <td></td>
                        <td></td>
                    </tr>
                    @*<tr>
                    <td>Mail Nickname:</td>
                    <td>@Html.EditorFor(Function(m) m.MailNickname)</td>
                    <td></td>
                    <td></td>
                </tr>*@
                    <tr>
                        <td>Display Name:</td>
                        <td>@Html.EditorFor(Function(m) m.DisplayName)</td>
                        <td></td>
                        <td></td>

                    </tr>
                    <tr>
                        <td>Web Role:</td>
                        <td>@Html.EditorFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_WebRole)</td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Customer:</td>
                        <td>
                            @code
                                Html.Kendo().DropDownListFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber) _
                                                                     .DataTextField("Name") _
                                                                     .DataValueField("CustomerNo") _
                                                                     .HtmlAttributes(New With {.style = "width:250px", .class = "form-control"}) _
                                                                     .AutoBind(True) _
                                                                     .DataSource(Sub(source)
                                                                                     source.Read(Function(read)
                                                                                                     read.Action("GetCustomers", "Customer")
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
                </table>
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

    </script>