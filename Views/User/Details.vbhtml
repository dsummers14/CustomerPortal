@ModelType CustomerPortal.UserProfileDetailsModel


@Code
    ViewData("Title") = "User Details"
End Code

<h2>User Details for @Model.UserProfileSEModel.Name </h2>

 @Html.ValidationSummary(True)

@Html.HiddenFor(Function(m) m.UserProfileSEModel.UserID)


<div id="iDetails">
    @Html.Partial("_UserProfileDetails")
</div>