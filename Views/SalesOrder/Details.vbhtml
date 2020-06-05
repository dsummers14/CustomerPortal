@ModelType Microsoft.NAV.salesOrder


@Code
    ViewData("Title") = "Order Details"
End Code

<h2>Sales Order Details</h2>

 @Html.ValidationSummary(True)

<div id="iGrid">
    @Html.Partial("_SalesOrderDetail")
</div>
