@Modeltype  string

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
          .Name("Description") _
          .DataTextField("Description") _
          .DataValueField("Description") _
          .HtmlAttributes(New With {.style = "width:300px"}) _
          .Filter("contains") _
          .MinLength(3) _
          .AutoBind(true) _
          .Events(Sub(e) e.Select("onSelectDescription")) _
          .DataSource(Sub(source)
                              source.Read(Function(read)
                                                  read.Action("GetItemsByDescription", "Item")
                                          End Function
                              ) _
                              .ServerFiltering(True)
                      End Sub) _
         .Render()
 end code

      