#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 21806
EXPOSE 44359

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["PictureService/PictureService.csproj", "PictureService/"]
RUN dotnet restore "PictureService/PictureService.csproj"
COPY . .
WORKDIR "/src/PictureService"
RUN dotnet build "PictureService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PictureService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PictureService.dll"]