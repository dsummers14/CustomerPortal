@ModelType b2c_ms_graph.UserModel


@Code
    ViewData("Title") = "Create User"
End Code

<h2>Create User</h2>

 @Html.ValidationSummary(True)



<div id="iDetails">
    @Html.Partial("_CreateUserGeneral")
</div>