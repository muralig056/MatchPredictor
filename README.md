# Match Predictor
Application to simulate the last 4 overs of the match, ball by ball using weighted random number generator.

# How to build and run
There are 2 ways to build the application
# 1. Through visual studio
   This is the usual way to buld and run the application
# 2. Through powershell using MSBuild project file
Added build.proj file under build folder where it has all the configurations to buils, run the application and tests.
## MSBuild
Builds the application in debug mode(based on the configuration)

Command: **ps> msbuild**

## RunsTests
This command will build the application first and then executes the unit tests.

Command: **ps> msbuild  .\build.proj /p:Configuration=Debug /t:RunMsTest**

## Start
This command will build the application and runs the application and the output can be seen in powershell console.

Command: **ps> msbuild  .\build.proj /p:Configuration=Debug /t:start**

## Steps to run the application
**I) using MSBuild**
1. Set the path to solutionsdirecoty in powershell
2. Execute the **Start** commands above
3. You will see the result in powershell console.
![alt tag](https://raw.githubusercontent.com/muralig056/MatchPredictor/master/resources/powershell-op.PNG)   

**II) using Visual studio**
Run the test application form visual studio.

## Code flow
There are 2 classes Team and Player where PLayer class will have all the logic to calculate player specific details(score, balls faced and etc.) and similarly the Team class.
The weighted random number generation is implemented at Player class **GetWeightedRandomNumber** where it will take a random number between 0 to 100 and gets the score based on the probability given.

**Here is how weighted random number generation works:**
There is a straightforward (steps)algorithm for picking an item at random, where items have individual weights:
1) Calculate the sum of all the weights
2) Pick a random number that is 0 or greater and is less than the sum of the weights
3) Go through the items one at a time, subtracting their weight from your random number, until you get the item where the random number is less than that item's weight

## Sample output
![alt tag](https://raw.githubusercontent.com/muralig056/MatchPredictor/master/resources/output.PNG)

## References
* https://stackoverflow.com/questions/1761626/weighted-random-numbers
* https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild?view=vs-2019
* https://help.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax
