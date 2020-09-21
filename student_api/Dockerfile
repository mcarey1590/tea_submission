FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["student_api/student_api.csproj", "student_api/"]
RUN dotnet restore "student_api/student_api.csproj"
COPY . .
WORKDIR "/src/student_api"
RUN dotnet build "student_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "student_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "student_api.dll"]
