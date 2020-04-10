@ModelType CustomerPortal.UserProfileSEModel

      <div class="k-content">
          @Html.HiddenFor(Function(m) m.UserID)
       
             <table>
              <tr>
                  <td>Password:</td>
                  <td>@Html.EditorFor(Function(m) m.Password)</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>New Password:</td>
                  <td>@Html.EditorFor(Function(m) m.NewPassword)</td>
                  <td></td>
                  <td></td>
              </tr>
               <tr>
                  <td>Confirm New Password:</td>
                  <td>@Html.EditorFor(Function(m) m.ConfirmPassword)</td>
                  <td></td>
                  <td></td>
              </tr>
          </table>
</div>

   
<script type="text/javascript">
  
  </script>