@Modeltype  String

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
             .DataTextField("Name") _
             .DataValueField("Code") _
             .HtmlAttributes(New With {.style = "width:250px"}) _
             .AutoBind(True) _
             .DataSource(Sub(source)
                                 source.Read(Function(read)
                                                     read.Action("GetTermsCodes", "TermsCode")
                                             End Function
                                 ) _
                                 .ServerFiltering(False)
                         End Sub) _
            .Enable(User.IsInRole("Admin") OrElse User.IsInRole("Sales Manager")) _
    .Render()
    
     
end code
