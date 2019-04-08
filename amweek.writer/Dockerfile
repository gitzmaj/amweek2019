#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-runtime-nanoserver-sac2016 AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY amweek.writer/amweek.writer.csproj amweek.writer/
COPY amweek.Entities/amweek.entities.csproj amweek.Entities/
COPY amweek.messaging/amweek.messaging.csproj amweek.messaging/
RUN dotnet restore amweek.writer/amweek.writer.csproj
COPY . .
WORKDIR /src/amweek.writer
RUN dotnet build amweek.writer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish amweek.writer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "amweek.writer.dll"]
