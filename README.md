# GitTrack App

The GitTrack App is a .Net 5 application to review some of the GitHub information publicly available, including: User, Repositories, Branches and Commits.

## Technologies

* Microsoft .Net 5
* Blazor
* EF Core v5.0
* Microsoft Identity v5.0
* NLog v4.7
* Moq v4.16
* MSTest v2.2
* Flurl v3.0
* MSSQL Server 2017
* Docker

## Installation

In this section we will walk through the steps the properly install and run the project using Microsoft Visual Studio and Docker in a Windows environment.

### Requirements

* Microsoft Visual Studio 2019 - v16.8.0+
* Docker Engine - v18.02.0+

### Process

Download or clone the GitHub Repository. See [Git Docs](https://git-scm.com/docs) for additional information on how to use Git.

Open the project in Visual Studio and run in order the following .Net commands in Visual Studio's Terminal

```
dotnet clean
dotnet restore
dotnet build
```

These commands will clean the solution output folders, restore all the dependancies and build the project using the default configuration. See [.Net CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/) for additional info.

After they complete run the following Docker command to download and build the required containers:

```
docker-compose up --build
```

This command will build and launch the containers based on the images from the "docker-compose.yml" file.

Note: The project is currently configured to use Windows containers.

### Debug

In order to debug the application using Visual Studio just configure the AppSettings.ConnectionString to point to an available SqlServer instance (Local, Remote or in a container) and launch the application using Visual Studio.

Note: To point the App to a container you should use the Nat IP Address from the Networking section.
 
Get the IP using, go to Networking and get the "Nat\IPAddress":

```
docker inspect {Id}
```

Where "Id" are the first 3 characters of the "Container Id". If you don't know the Id then use the following command while the container running:

```
docker ps
```

This command will show information about all the Docker containers currently running. See [Docker CLI](https://docs.docker.com/engine/reference/commandline/docker/) for additional info.

## Contributing
In order to contribute to the project your PRs should follow the GitFlow model, include Unit Tests and Test Cases for the Functional tests performed.

If any current Unit Test is affected by the changes then they must be updated accordingly.