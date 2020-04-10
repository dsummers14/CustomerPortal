@ModelType NaviAnywhere.ResetUserPasswordModel

@Using Html.BeginForm
    @<fieldset>
        <legend>Reset User Password</legend> 


@Code
    ViewData("Title") = "Reset User Password"
End Code

<h2>Reset User Password</h2>

 @Html.ValidationSummary(True)

 <div class="k-content">
       
         @Html.HiddenFor(Function(m) m.Token)
       
             <table>
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
        <p>
        @Html.Kendo.Button().Content("Submit").Name("Submit")
        @Html.Kendo.Button().Content("Exit").Name("Cancel").HtmlAttributes(New With {.onClick = "backtoIndex();return false;"})
      
 </p>     
   </fieldset>
End Using

<script type="text/javascript">
  
    function backtoIndex() {
        window.location.href = '@Url.Action("Index", "Home")';
     }

  </script>