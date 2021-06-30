#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 9007

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UserInfoService/UserInfoService.csproj", "UserInfoService/"]
COPY ["aspnetcoreDemo.Core.IServices/aspnetcoreDemo.Core.IServices.csproj", "aspnetcoreDemo.Core.IServices/"]
COPY ["aspnetcoreDemo.Core.Model/aspnetcoreDemo.Core.Model.csproj", "aspnetcoreDemo.Core.Model/"]
COPY ["aspnetcoreDemo.Core.Common/aspnetcoreDemo.Core.Common.csproj", "aspnetcoreDemo.Core.Common/"]
COPY ["Frameworks/Oxygen/Oxygen.IocModule/Oxygen.IocModule.csproj", "Frameworks/Oxygen/Oxygen.IocModule/"]
COPY ["Frameworks/Oxygen.Server/Oxygen.Server.Kestrel/Oxygen.Server.Kestrel.csproj", "Frameworks/Oxygen.Server/Oxygen.Server.Kestrel/"]
COPY ["Frameworks/Oxygen.Client/Oxygen.Client.ServerSymbol/Oxygen.Client.ServerSymbol.csproj", "Frameworks/Oxygen.Client/Oxygen.Client.ServerSymbol/"]
COPY ["Frameworks/Oxygen/Oxygen.Common/Oxygen.Common.csproj", "Frameworks/Oxygen/Oxygen.Common/"]
COPY ["Frameworks/Oxygen/Oxygen.ProxyGenerator/Oxygen.ProxyGenerator.csproj", "Frameworks/Oxygen/Oxygen.ProxyGenerator/"]
COPY ["Frameworks/Oxygen.Mesh/Oxygen.Mesh.Dapr/Oxygen.Mesh.Dapr.csproj", "Frameworks/Oxygen.Mesh/Oxygen.Mesh.Dapr/"]
COPY ["Frameworks/Oxygen.Client/Oxygen.Client.ServerProxyFactory/Oxygen.Client.ServerProxyFactory.csproj", "Frameworks/Oxygen.Client/Oxygen.Client.ServerProxyFactory/"]
COPY ["aspnetcoreDemo.Core.Repository/aspnetcoreDemo.Core.Repository.csproj", "aspnetcoreDemo.Core.Repository/"]
COPY ["aspnetcoreDemo.Core.Extension/aspnetcoreDemo.Core.Extension.csproj", "aspnetcoreDemo.Core.Extension/"]
RUN dotnet restore "UserInfoService/UserInfoService.csproj"
COPY . .
WORKDIR "/src/UserInfoService"
RUN dotnet build "UserInfoService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserInfoService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserInfoService.dll"]