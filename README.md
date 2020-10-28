# CardSorting
Made a few dips into microsoft's .net reference to help out with getting the unit tests up and running, but other than that, this went pretty smoothly.

The card sorting object is written using dependency inversion. Basically, that means its dependencies are passed to it through the constructor. Same applies to its dependencies.

This makes the project very easy to test. Also, if it were part of a larger project, it could be set up through a dependency injection container to have its dependencies supplied automatically, whenever it needs to be resolved.

This is somewhat demonstrated in the CardSorting unit tests, where a sort of poor man's DI is implemented in each test.

I went through pains to make sure the projects are as independent as possible. Every project has a single dependency to the Interfaces project, except for the test project, of course.
