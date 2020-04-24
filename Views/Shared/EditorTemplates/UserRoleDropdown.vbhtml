@Modeltype  String

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
             .DataTextField("RoleName") _
             .DataValueField("RoleID") _
             .HtmlAttributes(New With {.style = "width:150px"}) _
             .AutoBind(True) _
             .DataSource(Sub(source)
                                 source.Read(Function(read)
                                                     read.Action("GetRoles", "UserProfile")
                                             End Function
                                 ) _
                                 .ServerFiltering(False)
                         End Sub) _
    .Render()
    
     
end code
