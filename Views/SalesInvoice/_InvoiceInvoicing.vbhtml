@ModelType Microsoft.NAV.salesInvoice


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
                  <td>@Html.EditorFor(Function(m) m.billToName)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Bill-to Customer Address1:</td>
                  <td>@Html.EditorFor(Function(m) m.billingPostalAddress.street)</td>
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


  </script>