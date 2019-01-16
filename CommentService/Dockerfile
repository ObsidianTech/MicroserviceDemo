#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["CommentService/CommentService.csproj", "CommentService/"]
RUN dotnet restore "CommentService/CommentService.csproj"
COPY . .
WORKDIR "/src/CommentService"
RUN dotnet build "CommentService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CommentService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CommentService.dll"]