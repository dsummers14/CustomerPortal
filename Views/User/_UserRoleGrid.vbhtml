
@Code
    
    Html.Kendo.Grid(Of CustomerPortal.RoleModel) _
    .Name("UserRolesGrid") _
       .ToolBar(Sub(t) t.Create()) _
    .Columns(Sub(c)
                     c.Bound(Function(s) s.Description).EditorTemplateName("UserRoleDropdown")
                     c.Command(Function(commands) {commands.Edit, commands.Destroy})
             End Sub) _
 .DataSource(Sub(d)
                     d.Ajax _
                      .ServerOperation(False) _
                      .PageSize(20) _
                      .Model(Sub(m)
                                     m.Id(Function(s) s.UserID)
                                     m.Field(Function(s) s.RoleID).Editable(True)
                                     m.Field(Function(s) s.Description).Editable(True)
                             End Sub) _
                           .Events(Sub(e)
                                           e.Error("error_handler")
                                   End Sub) _
                     .Read(Function(r) r.Action("UserRole_Read", "UserProfile", New With {.UserID = Model.UserProfileSEModel.UserID})) _
                     .Create(Function(r) r.Action("UserRole_Create", "UserProfile", New With {.UserNo = Model.UserProfileSEModel.UserID})) _
                     .Update(Function(r) r.Action("UserRole_Update", "UserProfile")) _
                     .Destroy(Function(r) r.Action("UserRole_Delete", "UserProfile"))
             End Sub) _
 .Pageable() _
 .Filterable() _
 .Sortable() _
 .Render()
    
End Code

<script type="text/javascript">

    function error_handler(e) {
        if (e.errors) {
            var message = "Errors:\n";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function () {
                        message += this + "\n";
                    });
                }
            });
            alert(message);
        }
    }
      
</script>    