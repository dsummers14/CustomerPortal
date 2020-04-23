@ModelType Microsoft.NAV.salesQuote

      <div class="k-content">
          <table>
               <tr>
                  <td>Bill-to Customer No:</td>
                  <td>@Html.EditorFor(Function(m) m.billToCustomerNumber)</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Bill-to Customer Name:</td>
                  <td>@Html.TextBoxFor(Function(m) m.billToName, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Bill-to Customer Address1:</td>
                  <td>@Html.TextBoxFor(Function(m) m.billingPostalAddress.street, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Bill-to Customer City</td>
                  <td>@Html.EditorFor(Function(m) m.billingPostalAddress.city)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Bill-to Customer State:</td>
                  <td>@Html.EditorFor(Function(m) m.billingPostalAddress.state)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Bill-to Customer Zip:</td>
                  <td>@Html.EditorFor(Function(m) m.billingPostalAddress.postalCode)</td>
                  <td></td>
                  <td></td>
              </tr>


          </table>


      
      </div>

 
<script type="text/javascript">
  function onSelectCustomerNo(e) {
     var thisItem = this.dataItem(e.item.index());
      e.sender.close();

        //$('#BilltoCustomerName').data('kendoComboBox').dataSource.add({
        //    No: thisItem.No,
        //    Name: thisItem.Name
        //})

        //$('#BilltoCustomerName').data('kendoComboBox').select(function (dataItem) {
        //    return dataItem.No === thisItem.No;
        //});

        //e.sender.close();
  }

  //function onSelectCustomerName(e) {
  //    var thisItem = this.dataItem(e.item.index());

  //    $('#BilltoCustomerNo').data('kendoComboBox').dataSource.add({
  //        No: thisItem.No,
  //        Name: thisItem.Name
  //    })

  //    $('#BilltoCustomerNo').data('kendoComboBox').select(function (dataItem) {
  //        return dataItem.No === thisItem.No;
  //    });

  //    e.sender.close();
  //}


  </script>