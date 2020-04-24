@Modeltype  string

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
             .DataTextField("No") _
             .DataValueField("No") _
             .HtmlAttributes(New With {.style = "width:200px"}) _
             .Filter("contains") _
             .AutoBind(True) _
             .MinLength(3) _
            .Events(Sub(e)
                            e.Select("onSelectCustomerNo")
                            e.Change("onChangeCustomerNo")
                    End Sub) _
            .DataSource(Sub(source)
                                source.Read(Function(read)
                                                    read.Action("GetCustomersByCustomerNo", "Customer")
                                            End Function
                                ) _
                                .ServerFiltering(True)
                        End Sub) _
.Render()
End code

@Code
    Html.Kendo().Button() _
        .Name("customerlookupButton") _
        .Tag("em") _
        .SpriteCssClass("k-icon k-i-search") _
        .Events(Sub(e) e.Click("onCustomerLookup")) _
        .Content("<span class='k-sprite'>Lookup</span>") _
        .Render()
end code
