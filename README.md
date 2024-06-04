## Living Doc [Generate Report]

Step 1: 
$ Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

Step 2:
$ Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ livingdoc test-assembly SpecPage01.dll -t TestExecution.json

#### We Can also generate report at specified location-using relative or abs path

Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ livingdoc test-assembly SpecPage01.dll -t TestExecution.json --output ../../../report.html

#### Generate Report For Unused Steps In Step-Definations
Admin@DESKTOP-SRRVDGO E:\DotnetWorks\SpecPage01\bin\Debug\net8.0
$ livingdoc test-assembly SpecPage01.dll --binding-assemblies "SpecPage01.dll"

### Using dotnet Command Line Tool To Run Spec Tests


### Pass Value to appSettings.json from cmd
##### error command: dotnet run --AppSettings:Environment=Staging --AppSettings:RetryCount=10 --AppSettings:Browser=Firefox etc.

## NUnit	- Options To Run Tests
   -- FullyQualifiedName
   -- Name
   -- Category
   -- Priority


1. Run using single tag
   dotnet test --filter Category=wip
   dotnet test --filter "Category=wip1 | Category=wip2"    => run either 'wip1' OR 'wip2'
   dotnet test --filter "Category=wip1 & Category=wip2"    => run either 'wip1' AND 'wip2'

2. Add details in execution on console
   $ dotnet test <project-name> --no-build -v n

3. Run Filter by "scenario title" [Note remove space in title name]
   dotnet test BookShop.AcceptanceTests --filter Name~"Authorshouldbematched"
 

## Framework Support
1. Implement specflow page object model
2. Implement specflow+livingdoc report
3. Add appSettings.json to pass and access values
4. fully dotnet compitiable to run tests from commandline







