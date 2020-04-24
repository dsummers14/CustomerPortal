@modelType string

@(Html.Kendo().DropDownListFor(Function(m) m) _
    .BindTo(New List(Of String) From {"2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024"}) _
    .HtmlAttributes(New With {.style = "width:150px"})
    )

