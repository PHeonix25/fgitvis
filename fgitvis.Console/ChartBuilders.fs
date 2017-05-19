[<AutoOpen>]
module fgitvis.ChartBuilders

open FSharp.Charting

let internal columnChartBuilder (data: seq<string * int>, name: string, title: string, yAxis: string) =
    Chart.Column(data, Name = name)
        .WithTitle(title, InsideArea = false)
        .WithXAxis(LabelStyle = ChartTypes.LabelStyle(Angle = -45, Interval = 1.0))
        .WithYAxis(Title = yAxis)

let filesByCommitCountChart data =
    columnChartBuilder (data, "Commit counts", "Files by commit count", "# commits")

// TODO: Add additional "chartbuilders" here