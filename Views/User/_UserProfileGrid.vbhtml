@Code
    
    Html.Kendo.Grid(Of CustomerPortal.UserProfileSEModel) _
    .Name("UserProfilesGrid") _
     .ToolBar(Sub(t) t.Custom().Text("Add User").Action("CreateUserProfile", "UserProfile")) _
     .Columns(Sub(c)
                      c.Bound(Function(s) s.Name).Title("Email Address")
                      c.Bound(Function(s) s.CustomerNo)
                      c.Command(Function(commands) {commands.Custom("Details").Click("onDetailsClick"), commands.Destroy})
              End Sub) _
 .DataSource(Sub(d)
                     d.Ajax _
                      .ServerOperation(False) _
                      .PageSize(20) _
                      .Model(Sub(m)
                                     m.Id(Function(s) s.UserID)
                                     m.Field(Function(s) s.Name).Editable(True)
                                     m.Field(Function(s) s.EmailAddress).Editable(True)
                                     m.Field(Function(s) s.CustomerNo).Editable(True)
                             End Sub) _
                           .Events(Sub(e)
                                           e.Error("error_handler")
                                   End Sub) _
                     .Read(Function(r) r.Action("UserProfile_Read", "UserProfile")) _
                     .Create(Function(r) r.Action("UserProfile_Create", "UserProfile")) _
                     .Update(Function(r) r.Action("UserProfile_Update", "UserProfile")) _
                     .Destroy(Function(r) r.Action("UserProfile_Delete", "UserProfile"))
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
    
    
    function onDetailsClick(e) {
        e.preventDefault();
        var UserProfile = this.dataItem($(e.currentTarget).closest("tr"));
       
        window.location.href = '@Url.Action("Details","UserProfile")' + "?UserID=" + UserProfile.UserID;
    }

</script>    