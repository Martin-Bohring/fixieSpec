# fixieSpec #

Not much to see here yet.
This is a personal project for now to test drive my personal best of breed development stack (opinionated).

**Still here? OK.**

So you might wonder what I consider a good development stack in the .Net space.
As a general rule: **Things should be easly and low friction**.

**The follwing tools and frameworks I decided to test drive:**

## Building automation ##
There are build automation tools available in the .Net space that go further than plain MSBuild.
At the same time I want to avoid paying the XML tax as much as possible.

Therefore I tried [https://github.com/psake/psake](https://github.com/psake/psake "psake").
But I really never got the hang of the PowerShell syntax.

**Make no mistake here:**
It is a very good build automation tool, just not my kind of build automation tool.

The next thing I looked into is [https://github.com/fsharp/FAKE](https://github.com/fsharp/FAKE "FAKE").
That one has won me over. It has everything I want from build automation.
A rich eco-system, a great supportive community, and the address the right kind of problems.

An yes I am aware of [https://github.com/ruby/rake](https://github.com/ruby/rake "rake") and [https://github.com/cake-build/cake](https://github.com/cake-build/cake "Cake").

In my opinion Cake is the runner-up to Fake and might overtake it in the not to far future, but for now it is Fake.

## Continous Integration ##
Not to far back in time there were no free CI offerings available.
Boy have things changed by now (and no I have not lived in a cave for 10 years).

There are the following contenders I know of that offer free CI for open source projects:

- [http://codebetter.com/codebetter-ci/](http://codebetter.com/codebetter-ci/ "Codebetter Teamcity")
- [https://travis-ci.org/](https://travis-ci.org/ "Travis")
- [https://www.appveyor.com/](https://www.appveyor.com/ "AppVeyor")

Currently the AppVeyor CI server seems to be the most attractive option for me.

**Make no mistake here as well:**
All the offerings are free for open source projects, but for me AppVeyor seems to introduce the least amount of friction. At least for me.

BTW: Fake already supports reporting build progress to all of them.

I might consider [https://github.com/GitTools/GitLink](https://github.com/GitTools/GitLink "GitLink") and [https://www.nuget.org/](https://www.nuget.org/ "nuget") in case my little experiment ends up as a published Nuget package.

## Testing ##

### Test Framework ###
I have used [https://github.com/nunit](https://github.com/nunit "NUnit") professional in the past. It was a good option back then, but extending the test runner or changing the test class life cycle was always a hassle.
Also the test setup and test cleanup attributes always fetlt unnatural to me (remember low friction)

The [https://github.com/xunit/xunit](https://github.com/xunit/xunit "xunit") and relived from some of the pain.
Test class lifecycle is a more natural match with the expectations of a .Net developer.

Extending it is also possible, but still somewhat of a pain (and yes xunit2 has improved things in that area).

And then came [https://github.com/fixie/fixie](https://github.com/fixie/fixie "Fixie").
Its developer Patrick Lioi started developing it over the course of more than a year in the open.
His blog serie [https://lostechies.com/patricklioi/2013/07/23/fixies-elevator-pitch/](https://lostechies.com/patricklioi/2013/07/23/fixies-elevator-pitch/) is a must read for every fixie user.

All the decisions, doubts, mistakes, course changes etc. are laid out in plain sight.
So everybody can watch a great developer at work.

### Assertion Framework ###
Am a long time ueser of [https://github.com/dennisdoomen/FluentAssertions](https://github.com/dennisdoomen/FluentAssertions "Fluent Assertions"). It is simple the most complete fluent asserion library.

No matter what unit test framework I used in the past, I always had trouble what parameter comes first in its assertion methods:

Is it the actual value or the excpected value. Since both are of the same type (most of the time), the method signator is not helpfull. Fluent Assertions solves that and a lot more [https://github.com/dennisdoomen/FluentAssertions/wiki](https://github.com/dennisdoomen/FluentAssertions/wiki "Fluent Assertions Wiki").

The only draw back is that some of the exception messages are difficult to decipher.

But I want to learn something new. Therefore I will give [https://github.com/shouldly/shouldly](https://github.com/shouldly/shouldly "Shouldly") a try. I am aware of other Assertion Frameworks.

It is not as complete as Fluent Assertions, but they have worked exspecially on improving the error messages ([http://docs.shouldly-lib.net/v2.4.0/docs](http://docs.shouldly-lib.net/v2.4.0/docs "Documentation") look at the error message examples). 

### Mocking Library ###
Over the years I have used almost all of the mocking libraries in the .Net space that are freely available.

- [https://github.com/ayende/rhino-mocks](https://github.com/ayende/rhino-mocks "rhino-mocks")
- [https://github.com/moq/moq](https://github.com/moq/moq "moq")
- [https://github.com/FakeItEasy/FakeItEasy](https://github.com/FakeItEasy/FakeItEasy "FakeItEasy")

And yes I am aware of [https://github.com/nsubstitute/NSubstitute](https://github.com/nsubstitute/NSubstitute "NSubsitute"), but never used it professionally.

But for this endavour it will be **FakeItEasy**. It has the most clean syntax (personally opinion again, feel free to have your own)
Is super low friction, does the right thing out of the box,(Deep mocking anybody? Yes I am locking at you RhinoMocks and Moq) and just gets out of the way.

## fixieSpec ##

To test things out I decided to create a small specification framework.

You might ask: Why create a new specification framework?
There so many good ones already. And you would be right.
As mentioned already I am creating it to learn something new.
There is a lot to learn out there. Things change fast. A good approach from 2 years ago becomes outdated very quickly.

