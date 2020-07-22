@ModelType Microsoft.NAV.salesOrder

      <div class="k-content">
          <table>
              
               <tr>
                  <td>Ship-to  Name:</td>
                  <td>@Html.TextBoxFor(Function(m) m.shipToName, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td>Requested Delivery Date:</td>
                  <td>@Html.TextBoxFor(Function(m) m.requestedDeliveryDateString)</td>
              </tr>
              <tr>
                  <td>Ship-to  Address1:</td>
                  <td>@Html.TextBoxFor(Function(m) m.shippingPostalAddress.street, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Ship-to  City</td>
                  <td>@Html.EditorFor(Function(m) m.shippingPostalAddress.city)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Ship-to  State:</td>
                  <td>@Html.EditorFor(Function(m) m.shippingPostalAddress.state)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Ship-to  Zip:</td>
                  <td>@Html.EditorFor(Function(m) m.shippingPostalAddress.postalCode)</td>
                  <td></td>
                  <td></td>
              </tr>


          </table>


      
      </div>

 @*@code
     Html.Kendo.Window() _
  .Name("ShipToLookupWindow") _
  .Title("ShipTo Address Lookup") _
  .Visible(False) _
  .Resizable(Sub(r) r.Enabled(True)) _
  .Content(Function(ct)
                          @<div>
                             @Html.Partial("_ShipToAddressLookupWindow")
                          </div>     
                  End Function) _
     .Render()
     
 end code*@   

<script type="text/javascript">
  function onSelectShipToCode(e) {
        var thisItem = this.dataItem(e.item.index());
        e.sender.close();
  }

  function onChangeShipToCode(e) {
      $("form").submit();
  }

  function onShipToLookup(e) {
      e.preventDefault();

      var wnd = $("#ShipToLookupWindow").data("kendoWindow");
      wnd.center().open();
  };

  function onShipToLookupSelect(e) {
      var grid = this;
      var thisItem = grid.dataItem(grid.select());

          $('#ShiptoCode').data('kendoComboBox').dataSource.add({
              Code: thisItem.Code
          })

          $('#ShiptoCode').data('kendoComboBox').select(function (dataItem) {
              return dataItem.Code === thisItem.Code;
          });


         $('#ShiptoName').val(thisItem.Name);
        

      var wnd = $("#ShipToLookupWindow").data("kendoWindow");
      wnd.center().close();

      $("form").submit();
  };

  </script>
