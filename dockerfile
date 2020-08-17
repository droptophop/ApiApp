FROM mcr.microsoft.com/dotnet/core/sdk as publish
WORKDIR /app
# from the path on the physical machine to the image environment
COPY . .
RUN dotnet publish -c Release -o out ApiApp.Client/ApiApp.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /dist
COPY --from=publish /app/out /dist
CMD [ "dotnet", "ApiApp.Client.dll" ]