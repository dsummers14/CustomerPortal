@ModelType Microsoft.NAV.salesInvoice

@Code
    Html.Kendo.PanelBar() _
       .Name("InvoicePanelBar") _
       .ExpandMode(PanelBarExpandMode.Multiple) _
       .Items(Sub(t)
                  t.Add() _
          .Text("General") _
          .Expanded(True) _
      .Content(Function(ct)
    @<div>
        @Html.Partial("_InvoiceGeneral")
    </div>
               End Function)
        t.Add() _
        .Text("Lines") _
        .Expanded(True) _
        .Content(Function(ct)
@<div>
    @Html.Partial("_InvoiceLines")
</div>
End Function)
t.Add() _
.Text("Invoicing") _
.Content(Function(ct)
@<div>
    @Html.Partial("_InvoiceInvoicing")
</div>
         End Function)
        t.Add() _
        .Text("Shipping") _
        .Content(Function(ct)
@<div>
    @Html.Partial("_InvoiceShipping")
</div>
                 End Function)
              End Sub).Render()
End Code

<p>
    @Html.Kendo.Button().Content("Back").Name("Cancel").HtmlAttributes(New With {.onClick = "history.back();return false;"})
    @Html.Kendo.Button().Content("Email").Name("Email").HtmlAttributes(New With {.onClick = "onEmailClick();return false;"})
</p>

@*@code
    Html.Kendo.Window() _
        .Name("EmailWindow") _
        .Title("Email - Sales Invoice") _
        .Visible(False) _
        .Resizable(Sub(r) r.Enabled(True)) _
        .Draggable(True) _
        .Content(Function(ct)
        @<div>
            @Html.Partial("_EmailWindow", New NaviAnywhere.EmailModel With {.Subject = "Invoice " + Model.InvoiceHeader.DocumentNo,
                                                                            .EmailTo = NaviAnywhere.Customer.EmailAddreess(Model.InvoiceHeader.SelltoCustomerNo)})
        </div>
    End Function) _
       .Render()

end code*@

<script type="text/javascript">

    function backtoIndex() {
        var customerNo = $('#CustomerNo').val();
        window.location = 'Index?CustomerNo=' + customerNo;
    }

</script>   