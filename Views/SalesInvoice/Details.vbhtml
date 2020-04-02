@ModelType Microsoft.NAV.salesInvoice


@Code
    ViewData("Title") = "Invoice Details"
End Code

<h2>Sales Invoice Details</h2>



<div id="iGrid">
    @Html.Partial("_SalesInvoiceDetail")
</div>