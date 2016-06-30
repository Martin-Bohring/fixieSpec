# fixieSpec

![fixieSpec Logo](https://raw.github.com/Martin-Bohring/fixieSpec/master/assets/Fixiespec-256-01.png)

[![Build status](https://ci.appveyor.com/api/projects/status/0e3c8ei5n1297y9g?svg=true)](https://ci.appveyor.com/project/Martin-Bohring/fixiespec)

A super low friction specification framework based on the fantastic [Fixie](https://github.com/fixie/fixie "Fixie") test framework.

## Why fixieSpec?

You might ask: Why create another specification framework?
There are so many good ones already. And you would be right.
But I always have the feeling I have to do a lot for those frameworks until they start to do something for me.
Your mileage might vary depending on the chosen framework. I tried a lot of them believe me.

Either you have to use code generation (not a bad thing in itself, but friction), play some tricks with lambdas, being committed to a certain assertion library, or try to mimic Ruby frameworks (a lot of good ideas over there, but some things do not translate to c# without damage)

**Make no mistake here:**  
There are advantages and disadvantages for all approaches. So this approach has also not only advantages.
It is an opinionated framework for a start.

### So what tradeoffs does this framework make?

- **Super low friction specification authoring**  
  But that comes not for free. You have to follow a naming convention for your specifications. More on that later on.

- **Minimal ceremony**  
  Specifications are picked up automatically by using the [Fixie](https://github.com/fixie/fixie "Fixie") test framework for specification execution. `Fixie` is much more open to different styles of testing than fixieSpec.

- **One test class per scenario**  
  I strongly believe in independent unit tests (FIRST principle), however when it comes to specifications I value other traits higher. I very much favour a test class per scenario life cycle here. This allows to setup a context, execute some transitions (exercising the system under test) followed by one or more assertions. The different scenario classes should still be as independent from each other as possible.

- **From nothing to a specification in 10 minutes**  
  That is a bold statement, but after following the "Getting started" guide, you decide if it is true or not.

## Getting started

### How to get fixieSpec

`fixieSpec` is not yet published on Nuget.
So for the moment you can grab the [Latest build](https://ci.appveyor.com/project/Martin-Bohring/fixiespec "Latest build") or just pull the source and start from there.

I will setup Nuget publishing from the latest build in the near future. I just have to make up my mind what the versioning and branching strategy should be. This is easy to get wrong and difficult to fix when packages are already published.

### Writing you first specification

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
- The class is instantiated and its constructor parameters are resolved from somewhere
- A context setup step is executed after the class has been constructed
- A scenario specific transition step is executed on the SUT (system under test)
- Multiple assertion steps are executed in the order of their declaration

How is that done? If you follow the next steps, then you will understand how all that magic happens.

### Conventions used to write specifications

[Fixie](https://github.com/fixie/fixie "Fixie")  is a conventional test framework and so is `fixieSpec`. So it makes sense to consult the [Fixie documentation](http://fixie.github.io/ "Fixie documentation") before continuing.

Are you back? Fine. Now you know about the power of conventions and that is important, because `fixieSpec` leverages on that. `Fixie` allows to apply multiple conventions at the same time by using the [TestAssembly](http://fixie.github.io/docs/reusing-conventions/ "TestAssembly") class. But it is only useful when combining conventions that are not applied to the same set of tests or specifications for that matter.

Since `fixieSpec` has an opinion about test case naming and test class life cycle, its conventions need to be applied. To do that you need to create your own convention and inherit that from the `FixieSpecConvention` class.

The `FixieSpecConvention` makes the following assumptions about how to write specification:

- A specification class per scenario
- Specifications are broken down into simple steps
- There are different types of steps
  - Context setup steps that establish the context of the specification scenario
  - Transition steps that cause observable effects on the SUT or its dependencies
  - Assertion steps that verify direct output of the SUT, the state of the SUT or observe indirect output of the SUT (e.g. via the dependencies of the SUT)  
- An instance is created per specification class (The specification class is created and then all steps are executed in the order of declaration))
- Specification context setup that is not relevant for the scenario happens in the constructor
- Optionally primary scenario specific context setup happens in a `void` method named `Given..`
- Optionally further scenario specific context setup happens in `void` methods named `And_given...`
- The primary transition of the SUT (the exercising step of the scenario) happens in a `void`method named `When_..`
- Optional further transition of the SUT happens in `void` methods named `And_when...`
- The primary assertion (the verification) happens in a `void` method named `Then_...`
- Optional further assertions happen in `void`methods named `And_then...`
- Cleanup happens in an optional `Dispose` method (You have to implement `IDisposable` then)

The `FixieSpecConvention` makes no assumptions about:

- The casing of you specification methods
- Usage of underscores in your specification methods
- How you name your specification classes
- In which name spaces your specification classes are
- How your specification classes are instantiated.

The following convention class from the [Sample application](https://github.com/Martin-Bohring/fixieSpec/tree/master/Samples "Samples") shows how to establish you own conventions:

```c#
public class SpecificationConvention : FixieSpecConvention
{
    public SpecificationConvention()
    {
        Classes
            .Where(type => type.HasOnlyDefaultConstructor() || type.HasOnlyParameterConstructor());

        ClassExecution
            .UsingFactory(CreateFromFixture);
    }

    object CreateFromFixture(Type type)
    {
        var fixture = new Fixture();

        var instance = new SpecimenContext(fixture).Resolve(type);

        return instance;
    }
}
```

### So what does this convention tell us?

- Specifications are limited to classes with either a default constructor or a constructor with parameters.
  The base `FixieSpecConvention` makes no assumption about the names of specification classes or how the are instantiated.
  As a user of `fixieSpec` you can limit the number of classes that are considered as specifications. You can use all the possibilities of `Fixie` for that.  

- Specification instance creation happens through the `CreateFromFixture` factory method. More on that later on.

- The `CreateFromFixture` factory method is using `AutoFixture` to create specification class instances. More about that later on.

## Advanced scenarios

### Create your system under test (SUT) automatically

### SUT creation using AutoFixture

### SUT creation using a DI container

### Building from source

## What is missing

## Icon

Copyright by Paul Eichenberger, who contributed it.
I like how it combines a fixie bike (having one wheel only) with a checklist.
