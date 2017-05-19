open System
open Fake.Git
open fgitvis
open FSharp.Charting
open System.Windows.Forms

[<EntryPoint>]
let main argv = 

    printfn " ***************************************************************************"
    printfn " *                                                                         *"
    printfn " *   ########\  ######\  ######\ ########\ ##\    ##\ ######\  ######\     *"
    printfn " *   ##  _____|##  __##\ \_##  _|\__##  __|## |   ## |\_##  _|##  __##\    *"
    printfn " *   ## |      ## /  \__|  ## |     ## |   ## |   ## |  ## |  ## /  \__|   *"
    printfn " *   #####\    ## |####\   ## |     ## |   \##\  ##  |  ## |  \######\     *"
    printfn " *   ##  __|   ## |\_## |  ## |     ## |    \##\##  /   ## |   \____##\    *"
    printfn " *   ## |      ## |  ## |  ## |     ## |     \###  /    ## |  ##\   ## |   *"
    printfn " *   ## |      \######  |######\    ## |      \#  /   ######\ \######  |   *"
    printfn " *   \__|       \______/ \______|   \__|       \_/    \______| \______/    *"
    printfn " *                                                                         *"
    printfn " ***************************************************************************"
    printfn ""
    let now = DateTime.UtcNow.TimeOfDay
    printfn "Welcome to fgitvis. The time is %02d:%02d:%02d" now.Hours now.Minutes now.Seconds

    // Get some input for repo and file limit
    let repo = UserInput.requestRepositoryPath
    let fileLimit = UserInput.requestFileLimit
    
    // Set up the 'git' command - thanks FAKE
    let gitWrapper cmd = CommandHelper.getGitResult repo cmd
    let git command = Printf.kprintf gitWrapper command

    // Get the details from the local repository
    let getCommits () = git "rev-list HEAD"
    let getFiles commit = git "diff-tree --no-commit-id --name-only -r %s" commit
    let limit sequence = 
        match fileLimit with
        | 0 -> sequence
        | _ -> Seq.truncate fileLimit sequence

    let topFiles = 
        getCommits ()
        |> Seq.collect getFiles
        |> Seq.countBy id
        |> Seq.sortByDescending snd
        |> limit
    
    // Build and show the chart
    let buildChart (data: seq<string * int>) =
        Chart.Column(data, Name = "Commit counts")
            .WithTitle("Files by commit count", InsideArea = false)
            .WithXAxis(LabelStyle = ChartTypes.LabelStyle(Angle = -45, Interval = 1.0))
            .WithYAxis(Title="# commits")
    let showChart (chart: ChartTypes.GenericChart) =
        Application.Run(chart.ShowChart())
        
    topFiles 
    |> buildChart 
    |> showChart

    // ... and exit
    printfn ""
    printfn "Thanks for using fgitvis."
    0