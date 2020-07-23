@ModelType Microsoft.NAV.salesOrder

      <div class="k-content">
          @*@Html.HiddenFor(Function(m) m.id)
          @Html.HiddenFor(Function(m) m.number)*@
          <table>
              <tr>
                  <td>No:</td>
                  <td>@Html.EditorFor(Function(m) m.number)</td>
                  <td>Order Date:</td>
                  <td>@Html.EditorFor(Function(m) m.orderDate)</td>
              </tr>
               <tr>
                  <td>Sell-to Customer No:</td>
                  <td>@Html.EditorFor(Function(m) m.customerName)</td>
                  <td>Status:</td>
                  <td>@Html.TextBoxFor(Function(m) m.Status, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
               <tr>
                  <td>Sell-to Customer Name:</td>
                  <td>@Html.TextBoxFor(Function(m) m.customerName, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Sell-to Customer Address1:</td>
                  <td>@Html.TextBoxFor(Function(m) m.sellingPostalAddress.street, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Sell-to Customer City</td>
                  <td>@Html.EditorFor(Function(m) m.sellingPostalAddress.city)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Sell-to Customer State:</td>
                  <td>@Html.EditorFor(Function(m) m.sellingPostalAddress.state)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Sell-to Customer Zip:</td>
                  <td>@Html.EditorFor(Function(m) m.sellingPostalAddress.postalCode)</td>
                  <td></td>
                  <td></td>
              </tr>


          </table>
</div>

   @*@code
       Html.Kendo.Window() _
      .Name("CustomerLookupWindow") _
      .Title("Customer Lookup") _
      .Visible(False) _
      .Resizable(Sub(r) r.Enabled(True)) _
      .Draggable(True) _
     .Content(Function(ct)
                          @<div>
                             @Html.Partial("_CustomerLookupWindow")
                          </div>     
                   End Function) _
       .Render()
     
 end code*@   


<script type="text/javascript">
  function onSelectCustomerNo(e) {
        var thisItem = this.dataItem(e.item.index());
        e.sender.close();
  }

  function onChangeCustomerNo(e) {
      $("form").submit();
  }

  function onCustomerLookup(e) {
      e.preventDefault();

      var wnd = $("#CustomerLookupWindow").data("kendoWindow");
      wnd.center().open();
  };

  function onCustomerLookupSelect(e) {
      var grid = this;
      var thisItem = grid.dataItem(grid.select());

          $('#SelltoCustomerNo').data('kendoComboBox').dataSource.add({
              No: thisItem.No,
              Name: thisItem.Name
          })

          $('#SelltoCustomerNo').data('kendoComboBox').select(function (dataItem) {
              return dataItem.No === thisItem.No;
          });


         $('#SelltoCustomerName').val(thisItem.Name);
        

      var wnd = $("#CustomerLookupWindow").data("kendoWindow");
      wnd.close();

      $("form").submit();
  };

  </script>