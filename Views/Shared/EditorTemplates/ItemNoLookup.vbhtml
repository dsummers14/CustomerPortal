@Modeltype  string

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
             .DataTextField("No") _
             .DataValueField("No") _
             .HtmlAttributes(New With {.style = "width:150px"}) _
             .Filter("contains") _
             .AutoBind(True) _
             .MinLength(2) _
             .Events(Sub(e) e.Select("onSelectItemNo")) _
             .DataSource(Sub(source)
                                 source.Read(Function(read)
                                                     read.Action("GetItemsByItemNo", "Item")
                                             End Function
                                 ) _
                                 .ServerFiltering(True)
                         End Sub) _
    .Render()
    
    Html.Kendo().Button() _
    .Name("itemlookupButton") _
    .Tag("em") _
    .SpriteCssClass("k-icon k-i-search") _
    .Events(Sub(e) e.Click("onItemLookup")) _
    .Content("<span class='k-sprite'>Lookup</span>").Render()

      
end code

     