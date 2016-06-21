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
### Writing you first specification ###
### Naming conventions used to find specifications ###

## Advanced scenarios ##
### Create your system under test (SUT) automatically ###
### SUT creation using AutoFixture ###
### SUT creation using a DI container ###

## What is missing ##

## Icon ##
Copyright by Paul Eichenberger, who contributed it.
I like how it combines a fixi bike (having one wheel only) with a checklist.