[<AutoOpen>]
module fgitvis.GitOperations

open System
open Fake
open Fake.Git

// Set up the 'git' command - thanks FAKE
let internal gitWrapper = CommandHelper.getGitResult
let internal git repo = Printf.kprintf (gitWrapper repo)

// TODO: Add additional git commands in here... Anything that'll come in handy
let internal getCommits repo = git repo "rev-list HEAD"
let internal getFilesInCommit repo = git repo "diff-tree --no-commit-id --name-only -r %s"

let getFilesByCommitCount repo  = 
    getCommits repo
    |> Seq.collect (getFilesInCommit repo)
    |> Seq.countBy id 
    |> Seq.sortByDescending snd

// TODO: add other filters and queries here.
    