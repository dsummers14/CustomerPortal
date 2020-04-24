@ModelType Microsoft.NAV.item


@Code
    ViewData("Title") = "Item Details"
End Code

<h2>Item Details</h2>

 @Html.ValidationSummary(True)



<div id="iGrid">
    @Html.Partial("_ItemDetail")
</div>