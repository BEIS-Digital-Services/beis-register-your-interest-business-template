# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get update
RUN apt-get install -y nodejs

WORKDIR /src
COPY ["Beis.RegisterYourInterest/Beis.RegisterYourInterest.csproj", "Beis.RegisterYourInterest/"]
RUN dotnet restore "Beis.RegisterYourInterest/Beis.RegisterYourInterest.csproj"
COPY . .
WORKDIR "/src/Beis.RegisterYourInterest"
RUN dotnet build "Beis.RegisterYourInterest.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Beis.RegisterYourInterest.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Beis.RegisterYourInterest.dll"]
