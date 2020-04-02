@ModelType IEnumerable(Of Microsoft.NAV.salesOrder)

@Code
    Dim iGrid As WebGrid = New WebGrid(Model, canPage:=True, rowsPerPage:=20)
end code

@iGrid.GetHtml(tableStyle:="webgrid", headerStyle:="webgrid-header", footerStyle:="webgrid-footer",
                                alternatingRowStyle:="webgrid-alternating-row",
                                selectedRowStyle:="webgrid-selected-row",
                                rowStyle:="webgrid-row-style",
                                mode:=WebGridPagerModes.All, nextText:="Next", previousText:="Previous",
                           columns:=iGrid.Columns(
                                          iGrid.Column(format:=Function(model) Html.ActionLink(model.No, "Details", New With {.OrderNo = model.No}), columnName:="Number"),
                                          iGrid.Column("customerNumber", "Customer No"),
                                          iGrid.Column("customerName", "Customer Name")))        
    