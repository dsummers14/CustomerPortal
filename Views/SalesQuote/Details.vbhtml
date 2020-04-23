@ModelType Microsoft.NAV.salesQuote


@Code
    ViewData("Title") = "Quote Details"
End Code

<h2>Sales Quote Details</h2>

 @Html.ValidationSummary(True)


@*<div id="Nav">
    @Html.Partial("_CustomerNav", Model.CustomerNav)
</div>*@

<div id="iGrid">
    @Html.Partial("_SalesQuoteDetail")
</div>
