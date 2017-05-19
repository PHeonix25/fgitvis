[<AutoOpen>]
module fgitvis.UserInput

open System
open Fake

let internal menuOptions =
    [
        ("a", ("commit count", (GitOperations.getFilesByCommitCount, ChartBuilders.filesByCommitCountChart)));
        ("b", ("something else", (GitOperations.getFilesByCommitCount, ChartBuilders.filesByCommitCountChart)));
    ]

let requestMenuItem () =
    printfn ""
    printfn "Please choose what type of report you'd like to see: "
    for option in menuOptions do
        printfn "\t %s - %s" (fst option) (fst (snd option))
    printfn "";

    let userInput = UserInputHelper.getUserInput "Please choose a menu item: "
    if (String.IsNullOrWhiteSpace userInput) then
        failwith "You need to choose a valid menu option"
    
    let inputMatchesMenu input menu = 
        String.Equals(input, (fst menu), StringComparison.CurrentCultureIgnoreCase)
    let menuResult = List.find (inputMatchesMenu userInput) menuOptions
    
    snd menuResult; // from here on out, we don't care about the "letter"

let requestFileLimit =
    let userInput = UserInputHelper.getUserInput "Please enter a numeric limit to the number of files we should graph: "
    let success, limit = Int32.TryParse(userInput)
    if (not success) || limit < 0 then
        failwith "Limit must be a positive integer (or 0 if you want to show all files)."
    limit;