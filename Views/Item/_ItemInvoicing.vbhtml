@ModelType NaviAnywhere.Item

      <div class="k-content">
               
          <table>
              <tr>
                  <td>Costing Method:</td>
                  <td>@Html.TextBoxFor(Function(m) m.CostingMethod, New With {.class = "k-textbox", .disabled = "disabled"})</td>
                  <td>Unit Price:</td>
                  <td>@Html.TextBoxFor(Function(m) m.UnitPrice, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
               <tr>
                  <td>Standard Cost:</td>
                  <td>@Html.TextBoxFor(Function(m) m.StandardCost, New With {.class = "k-textbox", .disabled = "disabled"})</td>
                  <td>Unit Cost:</td>
                  <td>@Html.TextBoxFor(Function(m) m.UnitCost, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
               <tr>
                  <td>Last Direct Cost:</td>
                  <td>@Html.TextBoxFor(Function(m) m.DirectCost, New With {.class = "k-textbox", .disabled = "disabled"})</td>
                  <td>Allow Invoice Discount:</td>
                  <td>@Html.CheckBoxFor(Function(m) m.AllowInvoiceDiscount, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
              <tr>
                  <td>Sales Unit of Measure:</td>
                  <td>@Html.EditorFor(Function(m) m.SalesUnitofMeasure, New With {.class = "k-textbox", .disabled = "disabled"})</td>
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
                <td></td>
                  <td></td>
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
                  <td></td>
                  <td></td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td></td>
                   <td></td>
                  <td></td>
                  <td></td>
              </tr>

          </table>
</div>

