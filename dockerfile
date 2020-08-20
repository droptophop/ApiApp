# get base sdk image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as publish

# create working directory
WORKDIR /app

# copy the csproj file and restore any dependecies (via NuGet)
COPY . .
RUN dotnet restore ApiApp.Client/ApiApp.csproj

# build the release
COPY . .
RUN dotnet publish -c Release -o out

# generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "ApiApp.dll"]
