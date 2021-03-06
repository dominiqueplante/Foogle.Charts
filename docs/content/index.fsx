(*** hide ***)
#I "../../bin"
#r "../../packages/FSharp.Data.2.0.9/lib/net40/FSharp.Data.dll"
#I "../../bin"
#load "Foogle.Charts.fsx"
open Foogle
open System.Windows.Forms

(**
Foogle: F# Library for Google Charts (and HighCharts)
=====================================================

Foogle Charts is an easy to use F# wrapper for the Google Charts data visualization library.  It was written by members of the F# Data Science and Machine Learning working group.

This example demonstrates using a function defined in this library.

First, the following must be executed for running in an .FSX script file:

	#I "../../bin"
	#r "../../packages/FSharp.Data.2.0.9/lib/net40/FSharp.Data.dll"
	#I "../../bin"
	#load "Foogle.Charts.fsx"
	open Foogle
	open System.Windows.Forms

Second, we must define the data we wish to visualize.  In this case, we will break down the number of hours spent in a (24 hour) day by an individual performing various tasks:
*)

let tasks = 
  [ "Work", 11; 
  	"Eat", 2; 
  	"Commute", 2;
    "Watch TV", 2; 
    "Sleep", 7 ]

(**
Here is a pie chart generated by Foogle.Charts using Google Charts:
*)

(*** define-output:pie1 ***)
Chart.PieChart(tasks, Label = "Hours per Day")
|> Chart.WithTitle(Title = "Daily activities")
(*** include-it:pie1 ***)

(**

You should notice a few things in the generated chart:

* The pie graph has a title, "Daily Activites"
* You can see the percentages for each task represented in the generated pie graph.
* You will also see a color coded legend on the right hand side representing each slice of the graph.

There are a couple of ways you can interact with this pie graph:

* When you hover the mouse over an entry in the legend, it will be highligted in the pie graph.  
* When you hover over any piece of the pie, you will see the raw data in a pop-up tooltip.

Let's now put a pie hole in the pie graph:
*)

(*** define-output:pie2 ***)    
Chart.PieChart(tasks, Label = "Hours per Day")
|> Chart.WithTitle(Title = "Daily activities")
|> Chart.WithPie(PieHole = 0.5)
(*** include-it:pie2 ***)    

(**

Again, the same interactions are possible as the pie graph above without the hole in the middle.

Getting the library
-------------------

TODO: How to get the library

Building from Source
--------------------

Windows

1. open a command prompt
2. navigate to the root folder containing the code
3. run ``build.cmd``

Samples & documentation
-----------------------

The library comes with comprehensible documentation. 

It include a tutorial automatically generated from `*.fsx` files in [the content folder][content]. 

The API reference is automatically generated from Markdown comments in the library implementation.

 * [Tutorial](tutorial.html) contains a further explanation of this sample library.

 * [API Reference](reference/index.html) contains automatically generated documentation for all types, modules
   and functions in the library. This includes additional brief samples on using most of the
   functions.  You must build first, and find the folder generated under docs\output folder.
 
Contributing and copyright
--------------------------

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/fsprojects/FSharp.ProjectScaffold/tree/master/docs/content
  [gh]: https://github.com/fsprojects/FSharp.ProjectScaffold
  [issues]: https://github.com/fsprojects/FSharp.ProjectScaffold/issues
  [readme]: https://github.com/fsprojects/FSharp.ProjectScaffold/blob/master/README.md
  [license]: https://github.com/fsprojects/FSharp.ProjectScaffold/blob/master/LICENSE.txt

Troubleshooting
---------------

On a windows machine, you might encounter problems if you have McAfee anti-virus running.  Specifically "McAfee Agent Activity Log" might be shown when you have McAfee installed.

If you get the following error when trying to display a graph:

<pre>
	> System.Net.HttpListenerException (0x80004005): The process cannot access the file because it is being used by another process
	   at Microsoft.FSharp.Control.CancellationTokenOps.Start@1234-1.Invoke(Exception e)
	   at <StartupCode$FSharp-Core>.$Control.loop@435-40(Trampoline this, FSharpFunc`2 action)
	   at Microsoft.FSharp.Control.Trampoline.ExecuteAction(FSharpFunc`2 firstAction)
	   at Microsoft.FSharp.Control.TrampolineHolder.Protect(FSharpFunc`2 firstAction)
	   at <StartupCode$FSharp-Core>.$Control.-ctor@520-1.Invoke(Object state)
	   at System.Threading.QueueUserWorkItemCallback.WaitCallback_Context(Object state)
	   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
	   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
	   at System.Threading.QueueUserWorkItemCallback.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
	   at System.Threading.ThreadPoolWorkQueue.Dispatch()
	   at System.Threading._ThreadPoolWaitCallback.PerformWaitCallback()
	Stopped due to error
</pre>

Open a web browser and navigate to

	http://localhost:8081

If something shows up in the browser window, then there is something running on that port and you must change the port used in the Foogle.Charts code.  The easiest way to do this is:

1. Search the code for the following line and replace the port "8081" in "http://localhost:8081/" with different port

	let serverPath = "http://localhost:8081/" // replace 8081 with different non-used port

2. Rebuild so that all scripts get updated in the bin folder properly

3. (In Visual Studio) reset interactive Session

*)
