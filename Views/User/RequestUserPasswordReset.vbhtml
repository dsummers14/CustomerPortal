@ModelType NaviAnywhere.RequestUserPasswordResetModel

@Using Html.BeginForm
    @<fieldset>
        <legend>Reset User Password</legend> 


@Code
    ViewData("Title") = "Reset User Password"
End Code

<h2>Reset User Password</h2>

 @Html.ValidationSummary(True)

 <div class="k-content">
       
             <table>
              <tr>
                  <td>Email Address:</td>
                  <td>@Html.TextBoxFor(Function(m) m.EmailAddress, New With {.style = "width: 250px;"})</td>
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