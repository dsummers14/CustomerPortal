@Code

    Html.Kendo.Grid(Of Microsoft.NAV.item) _
        .Name("ItemsGrid") _
        .ToolBar(Sub(t) t.Template("<input class='k-textbox' id='searchbox'/>&nbsp;<button id='searchbutton'>Search</>")) _
        .Columns(Sub(c)
                     c.Bound(Function(s) s.No).ClientTemplate(Html.ActionLink("#=No#", "Details", New With {.ItemNo = "#=No#"}).ToHtmlString)
                     c.Bound(Function(s) s.Description)
                     c.Bound(Function(s) s.Unit_Cost).Format("{0:c}").Visible(User.IsInRole("Salesperson") OrElse User.IsInRole("Admin") OrElse User.IsInRole("Sales Manager"))
                     c.Bound(Function(s) s.Availability).ClientTemplate(Html.ActionLink("#=Availability#", "Drilldown", Nothing, New With {.onClick = "onClickInventory('#=No#'); return false;"}).ToHtmlString).Title("Availability")
                 End Sub) _
     .DataSource(Sub(d)
                     d.Ajax() _
             .ServerOperation(True) _
             .PageSize(20) _
             .Model(Sub(m)
                        m.Id(Function(s) s.No)
                        m.Field(Function(s) s.Description).Editable(False)
                        m.Field(Function(s) s.inventory).Editable(False)
                        m.Field(Function(s) s.Unit_Cost).Editable(False)
                        m.Field(Function(s) s.Availability).Editable(False)
                    End Sub) _
            .Events(Sub(e)
                        e.RequestEnd("requestend")
                        e.Error("error_handler")
                    End Sub) _
            .Read(Function(r) r.Action("Item_Read", "Item").Data("addSearch"))
                 End Sub) _
   .Pageable() _
   .Filterable() _
   .Sortable() _
   .Render()

End Code


   @code
       Html.Kendo.Window() _
        .Name("ItemAvailabilityWindow") _
        .Title("Item Availability") _
        .Visible(False) _
        .Resizable(Sub(r) r.Enabled(True)) _
        .Draggable(True) _
        .Content(Function(ct)
                          @<div>
                             @Html.Partial("_ItemAvailabilityGrid")
                          </div>     
                 End Function) _
    .Render()
     
 end code   



<script type="text/javascript">

    function requestend(e) {
        if (e.type == 'create') {
            var orderNo = e.response.Data[0].DocumentNo;
            window.location = "Item/Details?ItemNo=" + orderNo;
        }

        if ((e.type == "update") || (e.type == "create")) {
            this.read();
        }
    }

    function error_handler(e) {
        if (e.errors) {
            var message = "Errors:\n";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function () {
                        message += this + "\n";
                    });
                }

            });
            alert(message);
        }
    }

    jQuery(function () { jQuery("#searchbutton").kendoButton({}); });


    function addSearch() {
        return { SearchText: $('#searchbox').val() };
    }

    $('#searchbutton').click(function () {
        $('#ItemsGrid').data('kendoGrid').dataSource.read();
    });

    function onClickInventory(ItemNo) {
        var wnd = $("#ItemAvailabilityWindow").data("kendoWindow");
        var Grid = $("#ItemAvailabilityGrid").data("kendoGrid");

        wnd.title("Item Availability - " + ItemNo)
        $('#ItemNo').val(ItemNo);
        Grid.dataSource.read();
        wnd.center().open();
    }
</script>    