#### 0.1.0-alpha1 - 14.04.2016
* Initial barely usable release
* Supports a class per scenario specification lifecycle (instance per specification class in [Fixie](https://github.com/fixie "Fixie") lingo)
* Support setup specification steps
* Supports transition specification steps
* And of course supports assertion specification steps
* Multiple steps of each type are allowed, but they need to be by convention in the order:
 * Setup steps are void methods starting with Given or And_given by convention (multiple allowed)
 * Transition steps are void methods starting with Then or And_then by convention (multiple allowed)
 * Assertion steps are void methods starting with Then or And_then by convention (multiple allowed)
