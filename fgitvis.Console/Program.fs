open fgitvis
open FSharp.Charting
open System.Windows.Forms

[<EntryPoint>]
let main argv = 

    printfn ""
    printfn " *************************************************************************** "
    printfn " *                                                                         * "
    printfn " *   ########\  ######\  ######\ ########\ ##\    ##\ ######\  ######\     * "
    printfn " *   ##  _____|##  __##\ \_##  _|\__##  __|## |   ## |\_##  _|##  __##\    * "
    printfn " *   ## |      ## /  \__|  ## |     ## |   ## |   ## |  ## |  ## /  \__|   * "
    printfn " *   #####\    ## |####\   ## |     ## |   \##\  ##  |  ## |  \######\     * "
    printfn " *   ##  __|   ## |\_## |  ## |     ## |    \##\##  /   ## |   \____##\    * "
    printfn " *   ## |      ## |  ## |  ## |     ## |     \###  /    ## |  ##\   ## |   * "
    printfn " *   ## |      \######  |######\    ## |      \#  /   ######\ \######  |   * "
    printfn " *   \__|       \______/ \______|   \__|       \_/    \______| \______/    * "
    printfn " *                                                                         * "
    printfn " *************************************************************************** "
    printfn ""

    let chooseInput f =
      Seq.initInfinite id
      |> Seq.choose (fun _ -> f())
      |> Seq.head

    let repoChosen = chooseInput UserInput.requestRepo
    let reportChosen = chooseInput UserInput.requestMenuItem
    
    printfn "You've chosen well, we'll calculate the '%s' report now." reportChosen.Description

    let fileLimit = UserInput.requestFileLimit ()
    let applyLimit = 
      match fileLimit with
      | Some limit -> Seq.truncate limit
      | None -> id

    let showChart (chart: ChartTypes.GenericChart) = Application.Run(chart.ShowChart())
    
    // Step through our menu declarations and pull apart the operations to run
    reportChosen.Operation repoChosen
    |> applyLimit
    |> reportChosen.Chart
    |> showChart

    printfn ""
    printfn "Thanks for using fgitvis."
    0