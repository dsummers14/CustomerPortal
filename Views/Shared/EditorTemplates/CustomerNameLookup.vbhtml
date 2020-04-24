@Modeltype  string

@code
    Html.Kendo().ComboBoxFor(Function(m) m) _
          .DataTextField("Name") _
          .DataValueField("Name") _
          .HtmlAttributes(New With {.style = "width:300px"}) _
          .Filter("contains") _
          .MinLength(3) _
          .AutoBind(True) _
          .Events(Sub(e) e.Select("onSelectCustomerName")) _
          .DataSource(Sub(source)
                              source.Read(Function(read)
                                                  read.Action("GetCustomersByName", "Customer")
                                          End Function
                              ) _
                              .ServerFiltering(True)
                      End Sub) _
   .Render()
 end code

      