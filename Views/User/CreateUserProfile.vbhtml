@ModelType UserProfileDetailsModel


@Code
    ViewData("Title") = "Create User Profile"
End Code

<h2>Create User Profile</h2>

 @Html.ValidationSummary(True)



<div id="iDetails">
    @Html.Partial("_CreateUserProfileDetails")
</div>