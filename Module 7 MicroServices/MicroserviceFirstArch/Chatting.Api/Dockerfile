FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://+:84
EXPOSE 84

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Chatting.Api/Chatting.Api.csproj", "Chatting.Api/"]
RUN dotnet restore "Chatting.Api/Chatting.Api.csproj"
COPY . .
WORKDIR "/src/Chatting.Api"
RUN dotnet build "Chatting.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chatting.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chatting.Api.dll"]
