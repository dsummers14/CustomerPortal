@ModelType Microsoft.NAV.salesQuote

@Using Html.BeginForm
    @<fieldset>

        @Code
            Html.Kendo.PanelBar() _
               .Name("QuotePanelBar") _
               .ExpandMode(PanelBarExpandMode.Multiple) _
               .Items(Sub(t)
                t.Add() _
.Text("General") _
.Expanded(True) _
.Content(Function(ct)
        @<div>
            @Html.Partial("_QuoteGeneral")
        </div>
                   End Function)
                t.Add() _
 .Text("Lines") _
 .Expanded(True) _
 .Content(Function(ct)
@<div>
    @Html.Partial("_QuoteLines")
</div>
                        End Function)
                t.Add() _
.Text("Invoicing") _
.Content(Function(ct)
@<div>
    @Html.Partial("_QuoteInvoicing")
</div>
                     End Function)
                t.Add() _
        .Text("Shipping") _
        .Content(Function(ct)
@<div>
    @Html.Partial("_QuoteShipping")
</div>
                               End Function)
                          End Sub).Render()
        End Code

     <p>
         @Html.Kendo.Button().Content("Back").Name("Cancel").HtmlAttributes(New With {.onClick = "history.back();return false;"})
         @*@Html.Kendo.Button().Content("Update").Name("General")
         @Html.Kendo.Button().Content("Cancel").Name("Cancel").HtmlAttributes(New With {.onClick = "backtoIndex();return false;"})*@
         @Html.Kendo.Button().Content("Email").Name("Email").HtmlAttributes(New With {.onClick = "onEmailClick();return false;"})

         <!-- Html.Kendo.Button().Content("Cancel").Name("Cancel").HtmlAttributes(New With {.onClick = "history.back();return false;"}) -->
     </p>
    </fieldset>
            End Using

@*@code
    Html.Kendo.Window() _
        .Name("EmailWindow") _
        .Title("Email - Sales Quote") _
        .Visible(False) _
        .Resizable(Sub(r) r.Enabled(True)) _
        .Draggable(True) _
        .Content(Function(ct)
        @<div>
            @Html.Partial("_EmailWindow", New NaviAnywhere.EmailModel With {.Subject = "Sales Quote " + Model.number,
                                                                                          .EmailTo = NaviAnywhere.Customer.EmailAddreess(Model.customerNumber)})
        </div>
                 End Function) _
        .Render()

end code*@

@*@code
    Html.Kendo.Window() _
        .Name("PastSalesWindow") _
        .Title("Past Sales") _
        .Visible(False) _
        .Resizable(Sub(r) r.Enabled(True)) _
        .Draggable(True) _
        .Content(Function(ct)
        @<div>
            @Html.Partial("_PastSalesGrid", Model)
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