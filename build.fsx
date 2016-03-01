// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/build/FAKE/tools/FakeLib.dll"

open Fake
open System
open FixieHelper

// --------------------------------------------------------------------------------------
// Project metadata

// The name of the project 
// (used by attributes in AssemblyInfo, name of a NuGet package and directory in 'src')
let project = "FixieSpec"

// Short summary of the project
// (used as description in AssemblyInfo and as a short summary for NuGet package)
let summary = "Low friction specifications based on the fantastic Fixie test framework"

// List of author names (for NuGet package)
let authors = [ "Martin Bohring" ]

// Tags for your project (for NuGet package)
let tags = "Fixie BDD TDD testing"

// File system information 
// (<solutionFile>.sln is built during the building process)
let solutionFile  = "FixieSpec"

// Pattern specifying assemblies to be tested using Fixie
let testAssemblies = "build/*Tests*.dll"

let buildDir = "build"

// --------------------------------------------------------------------------------------
// Clean build results

Target "Clean" (fun _ ->
    CleanDirs [ buildDir ]
)

// --------------------------------------------------------------------------------------
// Build library & test projects

Target "Build" (fun _ ->
    // We would like to build only one solution
    !! (solutionFile + ".sln")
    |> MSBuildReleaseExt  "" ["VisualStudioVersion", "12.0"] "Rebuild"
    |> ignore
)

// --------------------------------------------------------------------------------------
// Run the unit tests using test runner

Target "RunTests" (fun _ ->
    !! testAssemblies
    |> Fixie (fun p ->
        { p with  TimeOut = TimeSpan.FromMinutes 20. })
)

Target "All" DoNothing

// --------------------------------------------------------------------------------------
// Dependencies

"Clean"
  ==> "Build"

"Build"
  ==> "RunTests"

"RunTests"
  ==> "All"


// start build
RunTargetOrDefault "All"
