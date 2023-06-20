# ![Vincent OS logo](Assets/logo.png) Vincent OS Shell
This is a derivative of the Terminal program in the Vincent OS App mini operating system.
 
## Installation

### Recommended installation
<a href="https://apps.microsoft.com/store/detail/9NV4W0334DS2?launch=true&mode=mini">
	<img src="https://get.microsoft.com/images/en%20dark.svg"/>
</a>
You can get the shell via the Microsoft Store: https://apps.microsoft.com/store/detail/vincent-os-shell/9NV4W0334DS2

### Alternative installation
You can get the separate installer via the releases page.

### Installation développeur
First all, clone the repo.

#### With Visual Studio 2022 Community
1. Open the project : Vincent.OS.Shell.sln
2. Build the project

#### With ``dotnet``
1. Access to the folder "src/Vincent.OS.Shell" with your terminal.
2. Enter the following command :
```
$ dotnet build 'Vincent.OS.Shell.csproj'
```
3. Access to the folder "bin" and all it's subfolders and launch with :
```
$ dotnet 'Vincent.OS.Shell.dll'
```

## Information
This project is open source with the following license: GPL-3.
