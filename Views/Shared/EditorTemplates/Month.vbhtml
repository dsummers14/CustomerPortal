@modeltype Integer

@(Html.Kendo().DropDownListFor(Function(m) m) _
    .DataTextField("Text") _
    .DataValueField("Value") _
    .BindTo(New List(Of SelectListItem) From {New SelectListItem With {.Text = "January", .Value = 1}, _
                                              New SelectListItem With {.Text = "February", .Value = 2}, _
                                               New SelectListItem With {.Text = "March", .Value = 3}, _
                                               New SelectListItem With {.Text = "April", .Value = 4}, _
                                               New SelectListItem With {.Text = "May", .Value = 5}, _
                                               New SelectListItem With {.Text = "June", .Value = 6}, _
                                               New SelectListItem With {.Text = "July", .Value = 7}, _
                                               New SelectListItem With {.Text = "August", .Value = 8}, _
                                               New SelectListItem With {.Text = "September", .Value = 9}, _
                                               New SelectListItem With {.Text = "October", .Value = 10}, _
                                               New SelectListItem With {.Text = "November", .Value = 11}, _
                                              New SelectListItem With {.Text = "December", .Value = 12}}) _
     .HtmlAttributes(New With {.style = "width:150px"})
     )