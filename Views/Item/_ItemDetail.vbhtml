 @Using Html.BeginForm
    @<fieldset>
        <legend>Details</legend> 

@Code
     Html.Kendo.PanelBar() _
        .Name("ItemPanelBar") _
        .ExpandMode(PanelBarExpandMode.Multiple) _
        .Items(Sub(t)
                   t.Add() _
                       .Text("General") _
                       .Expanded(True) _
                   .Content(Function(ct)
                                          @<div>
                                              @Html.Partial("_ItemGeneral")
                                           </div>     
                            End Function)

               End Sub).Render()
End Code

<p>
        @*@Html.Kendo.Button().Content("Update").Name("General")*@
        @Html.Kendo.Button().Content("Cancel").Name("Cancel").HtmlAttributes(New With {.onClick = "backtoIndex();return false;"})
      
 </p>     
</fieldset>
End Using

 

<script type="text/javascript">

    function backtoIndex() {
        window.location = 'Index';
        }
   
   
</script>