@ModelType b2c_ms_graph.UserModel
      <div class="k-content">
          <table>
              <tr>
                  <td>Email Address:</td>
                  <td>@Html.EditorFor(Function(m) m.Mail)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Display Name:</td>
                  <td>@Html.EditorFor(Function(m) m.DisplayName)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Customer:</td>
                  <td>
                      @code
                          Html.Kendo().DropDownListFor(Function(m) m.extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber) _
                                   .DataTextField("Name") _
                                   .DataValueField("CustomerNo") _
                                   .HtmlAttributes(New With {.style = "width:250px", .class = "form-control"}) _
                                   .AutoBind(True) _
                                   .DataSource(Sub(source)
                                                   source.Read(Function(read)
                                                                   read.Action("GetCustomers", "Customer")
                                                               End Function) _
                                                          .ServerFiltering(False)
                                               End Sub) _
                                   .Render()
                      End code
                  </td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Password:</td>
                  <td>@Html.EditorFor(Function(m) m.newPassword)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Confirm Password:</td>
                  <td>@Html.EditorFor(Function(m) m.confirmPassword)</td>
                  <td></td>
                  <td></td>
              </tr>

          </table>
</div>

   
<script type="text/javascript">
  
  </script>