[<AutoOpen>]
module fgitvis.UserInput

open System
open System.IO
open Fake

let requestRepositoryPath = 
    let userInput = UserInputHelper.getUserInput "Please enter a path to a Git repo: "
    if (String.IsNullOrWhiteSpace userInput) || not (Directory.Exists userInput) then
        failwith "The provided input was not a valid path to a directory."
    userInput
    
let requestFileLimit =
    let userInput = UserInputHelper.getUserInput "Please enter a numeric limit to the number of files we should graph: "
    let success, limit = Int32.TryParse(userInput)
    if (not success) || limit < 0 then
        failwith "Limit must be a positive integer (or 0 if you want to show all files)."
    limit
