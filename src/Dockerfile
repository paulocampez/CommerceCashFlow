# Base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.sln .

COPY ./src/*.csproj ./src/   
COPY ./src/CommerceCashFlow.Api/*.csproj ./src/CommerceCashFlow.Api/
COPY ./src/CommerceCashFlow.Application/*.csproj ./src/CommerceCashFlow.Application/
COPY ./src/CommerceCashFlow.Infrastructure/*.csproj ./src/CommerceCashFlow.Infrastructure/
COPY ./src/CommerceCashFlow.Core/*.csproj ./src/CommerceCashFlow.Core/
COPY ./src/CommerceCashFlow.Tests/*.csproj ./src/CommerceCashFlow.Tests/

COPY ./src/*.sln ./src/
RUN dotnet restore

# Copy the entire project
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Runtime image

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
# Copy wait-for-it.sh into our image
COPY ./src/wait-for-it.sh ./src/wait-for-it.sh
# Make it executable, in Linux
RUN chmod +x ./src/wait-for-it.sh
COPY --from=build-env /app/out .

# # Set the entry point
ENTRYPOINT ["dotnet", "CommerceCashFlow.Api.dll"]