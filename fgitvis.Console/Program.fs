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
    
    let reportChosen = UserInput.requestMenuItem();
    printfn "You've chosen well, we'll calculate the '%s' report now." (fst reportChosen)

    let fileLimit = UserInput.requestFileLimit    
    
    let showChart (chart: ChartTypes.GenericChart) = Application.Run(chart.ShowChart())
    
    // Step through our menu declarations and pull apart the operations to run
    (fst (snd reportChosen))
    |> (fun xs -> if fileLimit = 0 then xs else Seq.truncate fileLimit xs)
    |> snd (snd reportChosen)
    |> showChart

    printfn ""
    printfn "Thanks for using fgitvis."
    0