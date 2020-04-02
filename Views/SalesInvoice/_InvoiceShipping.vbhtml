@ModelType Microsoft.NAV.salesInvoice

      <div class="k-content">
          <table>
               <tr>
                  <td>Ship-to  Name:</td>
                  <td>@Html.TextBoxFor(Function(m) m.shipToName, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td></td>
                  <td></td>
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