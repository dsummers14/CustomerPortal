@ModelType b2c_ms_graph.UserModel


@Code
    ViewData("Title") = "Create User Profile"
End Code

<h2>Create User Profile</h2>

 @Html.ValidationSummary(True)



<div id="iDetails">
    @Html.Partial("_CreateUserDetails")
</div>