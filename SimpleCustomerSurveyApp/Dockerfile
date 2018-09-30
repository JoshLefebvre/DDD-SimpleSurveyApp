FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SimpleCustomerSurveyApp/SimpleCustomerSurveyApp.csproj", "SimpleCustomerSurveyApp/"]
COPY ["InfrastructureLayer/InfrastructureLayer.csproj", "InfrastructureLayer/"]
COPY ["DomainLayer/DomainLayer.csproj", "DomainLayer/"]
RUN dotnet restore "SimpleCustomerSurveyApp/SimpleCustomerSurveyApp.csproj"
COPY . .
WORKDIR "/src/SimpleCustomerSurveyApp"
RUN dotnet build "SimpleCustomerSurveyApp.csproj" -c Release -o /app

FROM build AS publish
# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
RUN dotnet publish "SimpleCustomerSurveyApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SimpleCustomerSurveyApp.dll"]