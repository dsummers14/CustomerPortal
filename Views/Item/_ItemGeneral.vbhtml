@ModelType Microsoft.NAV.item

      <div class="k-content">
          @Html.HiddenFor(Function(m) m.id)
          @Html.HiddenFor(Function(m) m.number)
        
          <table>
              <tr>
                  <td>No:</td>
                  <td>@Html.EditorFor(Function(m) m.number)</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Description:</td>
                  <td>@Html.TextBoxFor(Function(m) m.displayName, New With {.class = "k-textbox", .style = "width: 300px;"})</td>
                  <td>Quantity On Hand:</td>
                  <td>@Html.TextBoxFor(Function(m) m.inventory, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
               <tr>
                  <td>Base Unit of Measure:</td>
                  <td>@Html.EditorFor(Function(m) m.BaseUnitofMeasure)</td>
                  <td>Blocked:</td>
                  <td>@Html.EditorFor(Function(m) m.blocked, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
              <tr>
                  <td>Item Category Code:</td>
                  <td>@Html.EditorFor(Function(m) m.itemCategoryCode)</td>
                  <td>Unit Price:</td>
                  <td>@Html.TextBoxFor(Function(m) m.unitPrice, New With {.class = "k-textbox", .disabled = "disabled"})</td>
              </tr>
               <tr>
                  <td></td>
                  <td></td>
                  <td>Last Date Modified:</td>
                  <td>@Html.EditorFor(Function(m) m.lastDateTimeModified)</td>
              </tr>

          </table>
</div>

   
<script type="text/javascript">
 
  </script>