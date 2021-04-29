#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GitTracker.Portal/GitTracker.Portal.csproj", "GitTracker.Portal/"]
COPY ["GitTracker.Repository/GitTracker.Repository.csproj", "GitTracker.Repository/"]
COPY ["GitTracker.Domain/GitTracker.Domain.csproj", "GitTracker.Domain/"]
COPY ["GitTracker.SharedKernel/GitTracker.SharedKernel.csproj", "GitTracker.SharedKernel/"]
COPY ["GitTracker.Services/GitTracker.Services.csproj", "GitTracker.Services/"]
COPY ["GitTracker.Infrastructure/GitTracker.Infrastructure.csproj", "GitTracker.Infrastructure/"]
RUN dotnet restore "GitTracker.Portal/GitTracker.Portal.csproj"
COPY . .
WORKDIR "/src/GitTracker.Portal"
RUN dotnet build "GitTracker.Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitTracker.Portal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitTracker.Portal.dll"]