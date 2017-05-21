# fgitvis

```
 ***************************************************************************
 *                                                                         *
 *   ########\  ######\  ######\ ########\ ##\    ##\ ######\  ######\     *
 *   ##  _____|##  __##\ \_##  _|\__##  __|## |   ## |\_##  _|##  __##\    *
 *   ## |      ## /  \__|  ## |     ## |   ## |   ## |  ## |  ## /  \__|   *
 *   #####\    ## |####\   ## |     ## |   \##\  ##  |  ## |  \######\     *
 *   ##  __|   ## |\_## |  ## |     ## |    \##\##  /   ## |   \____##\    *
 *   ## |      ## |  ## |  ## |     ## |     \###  /    ## |  ##\   ## |   *
 *   ## |      \######  |######\    ## |      \#  /   ######\ \######  |   *
 *   \__|       \______/ \______|   \__|       \_/    \______| \______/    *
 *                                                                         *
 ***************************************************************************
 ```
 
[![Build Status](https://ci.appveyor.com/api/projects/status/ojqci6wyls9fj53j?svg=true)](https://ci.appveyor.com/project/PHeonix25/fgitvis)
[![License](https://img.shields.io/github/license/PHeonix25/fgitvis.svg)](https://github.com/PHeonix25/fgitvis/blob/master/LICENSE)
[![GitHub Issues](https://img.shields.io/github/issues-raw/pheonix25/fgitvis.svg)](https://github.com/PHeonix25/fgitvis/issues)
[![GitHub contributors](https://img.shields.io/github/contributors/PHeonix25/fgitvis.svg)](https://github.com/PHeonix25/fgitvis/)
![Awesomeness percentage](https://img.shields.io/badge/awesomeness-70%25-lightgrey.svg)

## What is this?

A Git repo visualiser, written in F#.

## ...but why?

I wrote about that [over here](https://hermens.com.au/2017/05/20/Making-fgitvis/).

## How can I use it?

1. Fork the repo
1. Clone it down
1. Open it in VS2017.2 (or newer)
1. Build it, and run it.
1. Answer some questions:
   1.  Point it at a repo (use `.` to query the local repo)
   2.  Choose a report to run (choose the letter you want)
   3.  Choose if you want to limit the results (`0` will return ALL)
1. Done!

***NOTE***: 
Once [this](https://github.com/Microsoft/visualfsharp/issues/2400) 
and [this](https://github.com/dotnet/netcorecli-fsc/issues/85) 
and [all of these](https://github.com/dotnet/project-system/issues?q=is%3Aopen+is%3Aissue+label%3AArea-F%23) 
are solved, we should be able to do it this way AND use the `dotnet` CLI tooling, 
but we're waiting on VS2017.3 (at least)...

For the moment, you need to choose `dotnet` CLI, or VS2017, and I chose 2017 (for now).

## Dependencies

We've tried to keep this app very light-weight, and only included the core requirements. Due to this, our dependency list is quite small:

- [FSharp.Core](https://github.com/fsharp/fsharp) (obviously)
- [FAKE.Lib](https://github.com/fsharp/FAKE/tree/master/src/app/FakeLib) (for the Git and UserInput helpers)
- [FSharp.Charting](https://fslab.org/FSharp.Charting/) (for the awesome charts)
