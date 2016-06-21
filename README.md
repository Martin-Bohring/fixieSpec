# fixieSpec #

![fixieSpec Logo](https://raw.github.com/Martin-Bohring/fixieSpec/master/assets/Fixiespec-256-01.png)

[![Build status](https://ci.appveyor.com/api/projects/status/0e3c8ei5n1297y9g?svg=true)](https://ci.appveyor.com/project/Martin-Bohring/fixiespec)

A super low friction specification framework based on the fantastic [Fixie](https://github.com/fixie/fixie "Fixie") test framework.

## Why fixieSpec? ##

You might ask: Why create another specification framework?
There are so many good ones already. And you would be right.

But I always have the feeling I have to do a lot for those frameworks until they start to do something for me.
Your mileage might vary depending on the choosen framework. I tried a lot of them believe me.

Either you have to use code generation (not a bad thing in itself), play some tricks with lambdas or
being comitted to a certain assertion library.

**Make no mistake here:**
There are advantages and disadvantages for all approaches. So this approach has also not only advantages.
It is an opinionated framework for a start.  

**So what tradeoffs does this framework make?**

- **Super low friction specifcation authoring**
  But that comes not for free. You have to follow a naming convention for your specifications. More on that later on.

- **Minimal ceromony**
  Specifications are picked up automatically by using the [Fixie](https://github.com/fixie/fixie "Fixie") test framework for specification execution. Fixie is much more open to different styles of testing than fixieSpec.

- **One test class per scenario**
  I strongly believe in independent unit tests (FIRST principle), however when it comes to specifications I value other traits higher. I very much favour a test class per scenario lifecycle here. This allows to setup a context, execute some transitions (exercising the system under test) followed by one or more assertions. The different scenario classes should still be as independend from each other as possible.

- **From nothing to a specification in 10 minutes**
  That is a bold statement, but after following the getting started guide, you decide if it is true.

## Getting started ##
### How to get fixieSpec ###
fixieSpec is not yet published on Nuget.
So for the moment you can grab the [Latest build](https://ci.appveyor.com/project/Martin-Bohring/fixiespec "Latest build") or just pull the source and start from there.

I will setup Nuget publishing from the latest build in the near future. I just have to make up my mind what the versioning and branching strategy should be. This is easy to get wrong and difficult to fix when packages are already published.

### Writing you first specification ###
A specification is a simple public class like the following from the [Sample application](https://github.com/Martin-Bohring/fixieSpec/tree/master/Samples "Samples"):

```c#
public sealed class AudioRecordingSucceedsWithMicrophone
{
    readonly Microphone microphone;

    readonly AudioRecording audioRecording;

    public AudioRecordingSucceedsWithMicrophone(
        AudioRecording anAudioRecording,
        Microphone aMicrophone)
    {
        audioRecording = anAudioRecording;
        microphone = aMicrophone;
    }

    public void Given_a_microphone_is_available()
    {
        microphone.MakeAvailable();
    }

    public void When_the_audio_recording_is_started()
    {
        audioRecording.StartRecording(microphone);
    }

    public void Then_the_audio_recording_should_be_recording()
    {
        audioRecording.ShouldBeRecording();
    }

    public void And_then_the_selected_microphone_is_used_for_recording()
    {
        microphone.ShouldBeRecording(audioRecording);
    }

    public void And_then_the_selected_microphone_is_not_available_anymore()
    {
        microphone.IsAvailable().ShouldBeFalse();
    }
}
```

As you can see this is a simple class with no frills, but a lot is happening in the background:

- The specification class is found by convention
- The class is instanciated and its constructor parameters are resolved from somewhere
- A context setup step is executed after the class has been constructed
- A scenario specific transition step is executed on the SUT
- Multiple assertion steps are executed in the order of their declaration

How is that done? If you follow the next steps, then you will understand how all that magic happens.
### Naming conventions used to find specifications ###

## Advanced scenarios ##
### Create your system under test (SUT) automatically ###
### SUT creation using AutoFixture ###
### SUT creation using a DI container ###
### Building from source ###

## What is missing ##

## Icon ##
Copyright by Paul Eichenberger, who contributed it.
I like how it combines a fixi bike (having one wheel only) with a checklist.
