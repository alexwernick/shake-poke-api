#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat



FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
RUN ping google.com
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["ShakePokeAPI/ShakePokeAPI.csproj", "ShakePokeAPI/"]
COPY ["ShakePokeAPI.Data/ShakePokeAPI.Data.csproj", "ShakePokeAPI.Data/"]
COPY ["ShakePokeAPI.Core/ShakePokeAPI.Core.csproj", "ShakePokeAPI.Core/"]
COPY ["ShakePokeAPI.Clients/ShakePokeAPI.Clients.csproj", "ShakePokeAPI.Clients/"]
COPY ["ShakePokeAPI.External/ShakePokeAPI.External.csproj", "ShakePokeAPI.External/"]
RUN dotnet restore "ShakePokeAPI/ShakePokeAPI.csproj"
COPY . .
WORKDIR "/src/ShakePokeAPI"
RUN dotnet build "ShakePokeAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ShakePokeAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShakePokeAPI.dll"]