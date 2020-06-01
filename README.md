#CO2 Emmision Calculator program

The program is a console application that returns the CO2-equivalent of emissions produced when traveling a given distance using a given transportation method.
The application was developed with Visual Studio 2019 and the target Framework is .NET Core 3.1. 
To install Visual Studio 2019 click [Visual Studio 2019](https://visualstudio.microsoft.com/vs/community/).
Nuget package libraries manually installed are System.CommadLine v2.0.0-beta1.20253.1 and xunit.runner.console v2.4.1. The other package libraries; namely coverlet.collector, Microsoft.NET.Test.Sdk, xunit and xunit.runner.visualstudio were installed by default.

##Usage
Users will interact with the application through the use of commands on the CLI (Command Line Interface).

###Command structure
```
<command> <argument> <option>
```
####Building the project
```
dotnet build
```
####Running the project
```
dotnet run <argument> <option>
```
####Executing the project
On the CLI, "cd" to the folder with the executable file.
```
$ ./co2-calculator.exe <argument> <option>
```
####Testing the project
```
dotnet test
```

##Pipeline
[Azure devops]()


## Sources
*[Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-clean)

*[Using Commandline parsing](https://blog.mastykarz.nl/building-cross-platform-cli-dotnet-core/)

*[Unit test Tutorial](https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019#create-a-unit-test-project)

*[XUnit Documentation](https://xunit.net/)
