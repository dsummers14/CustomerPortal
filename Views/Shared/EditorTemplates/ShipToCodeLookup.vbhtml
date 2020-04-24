@Modeltype  string

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
             .DataTextField("Name") _
             .DataValueField("Code") _
             .HtmlAttributes(New With {.style = "width:200px"}) _
             .Filter("contains") _
             .AutoBind(True) _
             .MinLength(3) _
            .Events(Sub(e)
                            e.Select("onSelectShipToCode")
                            e.Change("onChangeShipToCode")
                    End Sub) _
            .DataSource(Sub(source)
                                source.Read(Function(read)
                                                    read.Action("GetShipToCodes", "ShipToAddress").Data("getCustomerNo")
                                            End Function
                                ) _
                                .ServerFiltering(True)
                        End Sub) _
.Render()
End code

@Code
    Html.Kendo().Button() _
        .Name("shiptolookupButton") _
        .Tag("em") _
        .SpriteCssClass("k-icon k-i-search") _
        .Events(Sub(e) e.Click("onShipToLookup")) _
        .Content("<span class='k-sprite'>Lookup</span>") _
        .Render()
end code

<script type="text/javascript">
    function getCustomerNo() {
        return {
            CustomerNo: $('#SelltoCustomerNo').val()
           };
    }


</script>