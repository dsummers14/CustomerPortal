@ModelType CustomerPortal.UserProfileSEModel

      <div class="k-content">
             <table>
              <tr>
                  <td>Email Address:</td>
                  <td>@Html.EditorFor(Function(m) m.Name)</td>
                  <td></td>
                  <td></td>
              </tr>
              <tr>
                  <td>Customer:</td>
                  <td> @code 
                      Html.Kendo().DropDownListFor(Function(m) m.CustomerNo) _
                                       .DataTextField("Name") _
                                       .DataValueField("CustomerNo") _
                                       .HtmlAttributes(New With {.style = "width:250px", .class = "form-control"}) _
                                       .AutoBind(True) _
                                       .DataSource(Sub(source)
                                                           source.Read(Function(read)
                                                                               read.Action("GetCustomers", "PartTrakr")
                                                                       End Function) _
                                                                  .ServerFiltering(False)
                                                   End Sub) _
                                       .Render()
                      End code</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Password:</td>
                  <td>@Html.EditorFor(Function(m) m.NewPassword)</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Confirm Password:</td>
                  <td>@Html.EditorFor(Function(m) m.ConfirmPassword)</td>
                  <td></td>
                  <td></td>
              </tr>
          
          </table>
</div>

   
<script type="text/javascript">
  
  </script>