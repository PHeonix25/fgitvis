[<AutoOpen>]
module fgitvis.UserInput

open System
open System.IO
open Fake

let requestRepo () =     
    let userInput = UserInputHelper.getUserInput "Please enter a path to a Git repo (or use `.` for this repo): "
    if (String.IsNullOrWhiteSpace userInput) || not (Directory.Exists userInput) 
    then None
    else Some userInput

let requestMenuItem () =
    printfn ""
    printfn "Please choose what type of report you'd like to see: "

    let displayText (option: MenuOption) = (printfn "\t %s - %s" option.Option option.Description)
    List.iter displayText menuOptions
    printfn "";

    let userInput = UserInputHelper.getUserInput "Please choose a menu item: "
    
    let inputMatchesMenu input (menu: MenuOption) = 
        String.Equals(input, menu.Option, StringComparison.CurrentCultureIgnoreCase)

    List.tryFind (inputMatchesMenu userInput) menuOptions

let requestFileLimit () =
    let userInput = UserInputHelper.getUserInput "Please enter a numeric limit to the number of files we should graph: "
    let success, limit = Int32.TryParse(userInput)
    if success && limit > 0 
    then Some limit
    else None