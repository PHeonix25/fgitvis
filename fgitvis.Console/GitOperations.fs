[<AutoOpen>]
module fgitvis.GitOperations

open System
open System.IO
open Fake
open Fake.Git

let repo =     
    let userInput = UserInputHelper.getUserInput "Please enter a path to a Git repo: "
    if (String.IsNullOrWhiteSpace userInput) || not (Directory.Exists userInput) then
        failwith "The provided input was not a valid path to a directory."
    userInput

// Set up the 'git' command - thanks FAKE
let internal gitWrapper cmd = CommandHelper.getGitResult repo cmd
let internal git command = Printf.kprintf gitWrapper command

// TODO: Add additional git commands in here... Anything that'll come in handy
let internal getCommits = git "rev-list HEAD"
let internal getFilesInCommit commit = git "diff-tree --no-commit-id --name-only -r %s" commit

let getFilesByCommitCount = 
    getCommits 
    |> Seq.collect getFilesInCommit 
    |> Seq.countBy id 
    |> Seq.sortByDescending snd

// TODO: add other filters and queries here.
    