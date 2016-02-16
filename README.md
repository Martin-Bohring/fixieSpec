# fixieSpec #

Not much to see here yet.
This is a personal project for now to test drive my personal best of breed development stack (personal opinion).

Still here? OK.

So you might wonder what I consider a good development stack in the .Net space.
As a general rule: Things should be easly and low friction.

**The follwing list of tools and frameworks I decided to test drive:**

## Building automation ##
There are build automation tools available in the .Net space that go further than plain MSBuild.
At the same time I want to avoid paying the XML tax as much as possible.

Therefore I tried [https://github.com/psake/psake](https://github.com/psake/psake "psake").
But I really never got the hang of the PowerShell syntax.

**Make no mistake here:**
It is a very good build automation tool, just not my kind of build automation too.

The next thing I looked into is [https://github.com/fsharp/FAKE](https://github.com/fsharp/FAKE "FAKE").
That one has won me over. It has everything I want from build automation.
A rich eco-system, a great supportive community, and the address the right kind of problems.

An yes I am aware of [https://github.com/ruby/rake](https://github.com/ruby/rake "rake") and [https://github.com/cake-build/cake](https://github.com/cake-build/cake "Cake").

In my opinion Cake is the runner-up to Fake and might overtake it in the not to far future, but for now it is Fake.

## Continous Integration ##
Not to far back in time there were no free CI offerings available.
Boy have things changed by now (and no I have not lived in a cave for 10 years).

There are the following contenders that offer free CI for open source projects:

- [http://codebetter.com/codebetter-ci/](http://codebetter.com/codebetter-ci/ "Codebetter Teamcity")
- [https://travis-ci.org/](https://travis-ci.org/ "Travis")
- [https://www.appveyor.com/](https://www.appveyor.com/ "AppVeyor")

Currently the AppVeyor CI server seems to be the most attractive option for me.

**Make no mistake here as well:**
All the offerings are free for open source projects, but for me AppVeyor seems to introduce the least amount of friction. At least for me.

BTW: Fake supports reporting build progress for all of them.

I might consider [https://github.com/GitTools/GitLink](https://github.com/GitTools/GitLink "GitLink") and [https://www.nuget.org/](https://www.nuget.org/ "nuget") in case my little experiment ends up as a published Nuget package.

## Testing ##



## fixieSpec ##

To test things out I decided to create a small specification framework.
As you might be aware there 2 types of specification frameworks.

The ones intended to be used by developers and the ones targeting non developers.
This one will be for developers.

You might ask: Why create a new specification framework?
There so many good ones already. And you would be right.
As mentioned already I am crearting it to learn something new.
There is a lot to learn. Things change fast. A good approauch from 2 years ago becomes outdated very quickly.

This is the stack I am working with:

Fixie:

http://fixie.github.io](http://fixie.github.io).
