# Plastico-TodoList
Simple Console Todo list that utilizes SQLite.
![plastico](https://user-images.githubusercontent.com/64178604/116018944-1ca28580-a611-11eb-8aa3-5b21bad6b724.gif)

# Technologies
Project is created with:
* [CommandLineParser 2.9.0](https://www.nuget.org/packages/CommandLineParser/2.9.0-preview1)
* [SQLite Package 1.0.113.7](https://www.nuget.org/packages/System.Data.SQLite/)
* [DesktopNotifications.FreeDesktop](https://www.nuget.org/packages/DesktopNotifications.FreeDesktop/)
* [C# Dotnet 5.0103](https://dotnet.microsoft.com/)

## Setup
Install the [Dotnet 5.0103](https://dotnet.microsoft.com/) framework for C# and download the [SQLite 1.0](https://www.nuget.org/packages/System.Data.SQLite/)  and [CommandLineParser 2.9.0](https://www.nuget.org/packages/CommandLineParser/2.9.0-preview1) nuget package.
```
$ sudo dnf install dotnet-runtime-5.0
$ git clone https://github.com/SugarBlank/Plastico-TodoList/
$ cd ../Plastico-TodoList
$ dotnet add package CommandLineParser --version 2.9.0-preview1
$ dotnet add package System.Data.SQLite.Core --version 1.0.113.7
$ dotnet add package DesktopNotifications.FreeDesktop --version 1.0.0
$ sudo dotnet publish -r linux-x64 -o /usr/local/bin/ /p:PublishTrimmed=true /p:PublishSingleFile=true
```
Publish trimmed is for the file to remove uneeded dependencies since dotnet uses a lot of dependencies, and single file is for the app to be compiled as a single file than multiple dlls.
## License
[MIT](https://choosealicense.com/licenses/mit/)

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Suggestions for places to clean up code would be great too.

Please make sure to update tests as appropriate.
