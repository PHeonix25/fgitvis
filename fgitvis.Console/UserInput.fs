[<AutoOpen>]
module fgitvis.UserInput

open System
open Fake

let requestMenuItem () =
    printfn ""
    printfn "Please choose what type of report you'd like to see: "

    let displayText (option: MenuOption) = (printfn "\t %s - %s" option.Option option.Description)
    List.iter displayText menuOptions
    printfn "";

    let userInput = UserInputHelper.getUserInput "Please choose a menu item: "
    if (String.IsNullOrWhiteSpace userInput) then
        failwith "You need to choose a valid menu option."
    
    let inputMatchesMenu input (menu: MenuOption) = 
        String.Equals(input, menu.Option, StringComparison.CurrentCultureIgnoreCase)

    let result = 
        match List.tryFind (inputMatchesMenu userInput) menuOptions with
        | None -> failwith "Sorry, please choose one of the character prefixes for your required report."
        | Some result -> result
    
    result;

let requestFileLimit =
    let userInput = UserInputHelper.getUserInput "Please enter a numeric limit to the number of files we should graph: "
    let success, limit = Int32.TryParse(userInput)
    if (not success) || limit < 0 then
        failwith "Limit must be a positive integer (or 0 if you want to show all files)."
    limit;