#### 0.2.0-alpha2 - 09.09.2016

* Use fixiespec to test fixiespec where it simplifies existing tests - https://github.com/Martin-Bohring/fixieSpec/issues/18

#### 0.2.0-alpha1 - 07.08.2016

* Implemented asynchronous assertion steps - https://github.com/Martin-Bohring/fixieSpec/issues/5
* Implemented asynchronous setup steps - https://github.com/Martin-Bohring/fixieSpec/issues/3
* Implemented asynchronous transition steps - https://github.com/Martin-Bohring/fixieSpec/issues/4

#### 0.1.0-alpha4 - 06.07.2016

* BUGFIX: Fixed SourceLink not happening for non master branch builds e55aeeeca90a44c45820f44ab40f09d04d823a8d

#### 0.1.0-alpha3 - 06.07.2016

* Implemented semantic versioning an a matching CI build- https://github.com/Martin-Bohring/fixieSpec/issues/13
* Pull in the Roslyn Compiler to allow building in .Net 4.5 environments

#### 0.1.0-alpha2 - 01.07.2016

* Created sample project
* Added StyleCop analyzer and fixed warnings
* Updated dependencies to the newest versions
* Improved the CI build (still WIP)

#### 0.1.0-alpha1 - 14.04.2016

* Initial barely usable release
* Supports a class per scenario specification life cycle (instance per specification class in [Fixie](https://github.com/fixie "Fixie") lingo)
* Support setup specification steps
* Supports transition specification steps
* And of course supports assertion specification steps
* Multiple steps of each type are allowed, but they need to be by convention in the order:
  * Setup steps are void methods starting with Given or And_given by convention (multiple allowed)
  * Transition steps are void methods starting with Then or And_then by convention (multiple allowed)
  * Assertion steps are void methods starting with Then or And_then by convention (multiple allowed)
