[<AutoOpen>]
module fgitvis.MenuOptions

open FSharp.Charting

type MenuOption = { 
    Option: string; 
    Description: string; 
    Operation: string -> seq<string * int>; 
    Chart: (seq<string * int>) -> ChartTypes.GenericChart; 
}

let menuOptions =
    [
        { 
            Option = "a"; 
            Description = "files by commit count"; 
            Operation = GitOperations.getFilesByCommitCount; 
            Chart = ChartBuilders.filesByCommitCountChart; 
        };
        { 
            Option = "b"; 
            Description = "file modifications by time"; 
            Operation = GitOperations.getFilesByCommitCount; 
            Chart = ChartBuilders.filesOverTime; 
        };
        { 
            Option = "z"; 
            Description = "test"; 
            Operation = GitOperations.getFilesByCommitCount; 
            Chart = ChartBuilders.filesByCommitCountChart; 
        };
    ]