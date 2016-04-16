// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/build/FAKE/tools/FakeLib.dll"

open Fake
open Fake.AssemblyInfoFile
open Fake.ReleaseNotesHelper
open System
open System.IO
open FixieHelper

// --------------------------------------------------------------------------------------
// Project metadata

// The name of the project 
// (used by attributes in AssemblyInfo, name of a NuGet package and directory in 'src')
let project = "FixieSpec"

// Short summary of the project
// (used as description in AssemblyInfo and as a short summary for NuGet package)
let summary = "A super low friction specification test framework based on the fantastic Fixie test framework."

// Longer description of the project
// (used as a description for NuGet package; line breaks are automatically cleaned up)
let description = "A super low friction specification test framework based on the fantastic Fixie test framework."

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

// Read additional information from the release notes document
let releaseNotesData = 
    File.ReadAllLines "RELEASE_NOTES.md"
    |> parseAllReleaseNotes

let release = List.head releaseNotesData

let stable = 
    match releaseNotesData |> List.tryFind (fun r -> r.NugetVersion.Contains("-") |> not) with
    | Some stable -> stable
    | _ -> release

let genFSAssemblyInfo (projectPath) =
    let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
    let folderName = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(projectPath))
    let basePath = "src" @@ folderName
    let fileName = basePath @@ "AssemblyInfo.fs"
    CreateFSharpAssemblyInfo fileName
      [ Attribute.Title (projectName)
        Attribute.Product project
        Attribute.Company (authors |> String.concat ", ")
        Attribute.Description summary
        Attribute.Version release.AssemblyVersion
        Attribute.FileVersion release.AssemblyVersion
        Attribute.InformationalVersion release.NugetVersion ]

let genCSAssemblyInfo (projectPath) =
    let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
    let folderName = System.IO.Path.GetDirectoryName(projectPath)
    let basePath = folderName @@ "Properties"
    let fileName = basePath @@ "AssemblyInfo.cs"
    CreateCSharpAssemblyInfo fileName
      [ Attribute.Title (projectName)
        Attribute.Product project
        Attribute.Description summary
        Attribute.Version release.AssemblyVersion
        Attribute.FileVersion release.AssemblyVersion
        Attribute.InformationalVersion release.NugetVersion ]

// Generate assembly info files with the right version & up-to-date information
Target "AssemblyInfo" (fun _ ->
    let fsProjs =  !! "src/**/*.fsproj"
    let csProjs = !! "src/**/*.csproj"
    fsProjs |> Seq.iter genFSAssemblyInfo
    csProjs |> Seq.iter genCSAssemblyInfo
)

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
  ==> "AssemblyInfo"
  ==> "Build"

"Build"
  ==> "RunTests"

"RunTests"
  ==> "All"

// start build
RunTargetOrDefault "All"
