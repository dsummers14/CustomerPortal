@Modeltype  String

@code
    Html.Kendo().DropDownListFor(Function(m) m) _
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

end code
