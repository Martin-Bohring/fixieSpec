// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/build/FAKE/tools/FakeLib.dll"

open Fake

// Default Target
Target "Default" (fun _ ->
        trace "Nothing to see here yet"
)

// start build
RunTargetOrDefault "Default"
