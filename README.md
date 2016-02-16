# FixieSpec #

Not much to see here yet.
This is a personal project for now to try out my best of breed development stack (personal opinion).

Still here? OK.

So you might wonder what I consider a good development stack.
As a general rule: Things should be easly and low friction.

The follwing list of tools and frameworks I decided to test drive:

## Building automation ##
There are build automation tools available in the .Net space that go further than plain MSBuild.
At the same time I want to avoid paying the XML tax as much as possible.

Therefore I tried [https://github.com/psake/psake](https://github.com/psake/psake "psake").
But I really never got the hang of the PowerShell syntax.

**Make no mistake here:** It is a very good build automation tool, just not my kind of build automation too.

The next thing I looked into is [https://github.com/fsharp/FAKE](https://github.com/fsharp/FAKE "FAKE").
That one has won me over. It has everything I want from build automation.
A rich eco-system, a great supportive community, and the address the right kind of problems.

An yes I am aware of [https://github.com/ruby/rake](https://github.com/ruby/rake "rake") and [https://github.com/cake-build/cake](https://github.com/cake-build/cake "Cake").

In my opinion Cake is the runner-up to 

## Testing ##

###  ###

To test things out I decided to create a small specification framework.
As you might be aware there 2 types of specification frameworks.

The ones intended to be used by developers and the ones targeting at non developers.
This one will be for devlopers.

You might ask: Why create a new specification framework?
There so many good ones already. And you would be right.
As mentioned already I am crearting it to learn something new.
There is a lot to learn. Things change fast. A good approauch from 2 years ago becomes outdated very quickly.

This is the stack I am working with:

Fixie:

http://fixie.github.io](http://fixie.github.io).
