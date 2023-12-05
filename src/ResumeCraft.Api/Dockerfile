FROM alpine AS base
RUN apk add aspnetcore7-runtime
ENV DOTNET_URLS=http://+:5006
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ResumeCraft.Api/*.csproj", "ResumeCraft.Api/"]
COPY ["ResumeCraft.Application/*.csproj", "ResumeCraft.Application/"]
COPY ["ResumeCraft.Domain/*.csproj", "ResumeCraft.Domain/"]
COPY ["ResumeCraft.Infrastructure/*.csproj", "ResumeCraft.Infrastructure/"]
COPY ["ResumeCraft.Persistence/*.csproj", "ResumeCraft.Persistence/"]
RUN dotnet restore "ResumeCraft.Api/ResumeCraft.Api.csproj"
COPY . .
WORKDIR "/src/ResumeCraft.Api"
RUN dotnet build "ResumeCraft.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResumeCraft.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResumeCraft.Api.dll"]