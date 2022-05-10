FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# COPY ALL .csproj FILES
COPY "AdventureApp.Web/AdventureApp.Web.csproj" "AdventureApp.Web/AdventureApp.Web.csproj"
COPY "AdventureApp.Services/AdventureApp.Services.csproj" "AdventureApp.Services/AdventureApp.Services.csproj"
COPY "AdventureApp.DataAccess/AdventureApp.DataAccess.csproj" "AdventureApp.DataAccess/AdventureApp.DataAccess.csproj"
# RESTORE PACKAGES
RUN dotnet restore "AdventureApp.Web/AdventureApp.Web.csproj"
# COPY EVERYTHING ELSE
COPY . .
RUN dotnet build "AdventureApp.Web/AdventureApp.Web.csproj" -c Release -o /app

# RUN UNIT TESTS
RUN dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput="/coverage"

FROM build AS publish
RUN dotnet publish "AdventureApp.Web/AdventureApp.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AdventureApp.Web.dll"]