@Modeltype  String

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
             .DataTextField("displayName") _
             .DataValueField("id") _
             .HtmlAttributes(New With {.style = "width:250px"}) _
             .AutoBind(True) _
             .DataSource(Sub(source)
                             source.Read(Function(read)
                                             read.Action("GetCompanies", "Company")
                                         End Function
                     ) _
                     .ServerFiltering(False)
                         End Sub) _
    .Render()


end code
