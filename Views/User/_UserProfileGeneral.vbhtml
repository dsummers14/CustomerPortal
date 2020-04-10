@ModelType CustomerPortal.UserProfileSEModel

      <div class="k-content">
          @Html.HiddenFor(Function(m) m.UserID)
       
             <table>
               <tr>
                  <td>Email Address:</td>
                  <td>@Html.EditorFor(Function(m) m.Name)</td>
                  <td></td>
                  <td></td>
              </tr>
                 <tr>
                     <td>Customer:</td>
                     <td>@Html.EditorFor(Function(m) m.CustomerNo)</td>
                     <td></td>
                     <td></td>
                 </tr>
             </table>
</div>


<script type="text/javascript">

  </script>