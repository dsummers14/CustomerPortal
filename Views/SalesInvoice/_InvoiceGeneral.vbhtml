@ModelType Microsoft.NAV.salesInvoice

      <div class="k-content">
           @*@Html.HiddenFor(Function(m) m.Key)
           @Html.HiddenFor(Function(m) m.DocumentNo)
           @Html.HiddenFor(Function(m) m.DocumentType)*@

          <table>
              <tr>
                  <td>No:</td>
                  <td>@Html.EditorFor(Function(m) m.number)</td>
                  <td>Invoice Date:</td>
                  <td>@Html.Kendo.TextBoxFor(Function(m) m.invoiceDateString)</td>
              </tr>
               <tr>
                  <td>Sell-To Customer No:</td>
                  <td>@Html.EditorFor(Function(m) m.customerNumber)</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Sell-to Customer Name:</td>
                  <td>@Html.EditorFor(Function(m) m.customerName)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Sell-to Customer Address1:</td>
                  <td>@Html.EditorFor(Function(m) m.sellingPostalAddress.street)</td>
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


<script type="text/javascript">
  
  </script>