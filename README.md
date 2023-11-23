# Run tests

1. Install .Net in version 8
2. Install Git
3. Run following commands in terminal: 
   ```
        git clone https://github.com/kradej/dotnet-selenium.git
        cd dotnet-selenium
        dotnet build
        dotnet test
   ```

# How to setup new env for .Net + Selenium + NUnit in VS Code

1. Download and install .Net 8
2. Create new console application: 
   ```
        dotnet new console --framework net8.0 --use-program-main
   ```
3. Run:
    ```
        dotnet add package Selenium.WebDriver
        dotnet add package Selenium.WebDriver.ChromeDriver
        dotnet add package Selenium.Support
        dotnet add package Microsoft.NET.Test.Sdk
        dotnet add package NUnit
        dotnet add package NUnit3TestAdapter
    ```
4. Remove `Program.cs` file
5. Add test classes accotring to NUnit syntax
6. To build project use: 
   ```
        dotnet build
   ``` 
7. To run test use this command:
   ```
        dotnet test
   ```