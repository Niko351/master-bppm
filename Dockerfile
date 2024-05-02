FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-dev
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out /p:EnvironmentName={ENVIRONMENT_NAME} ./{PROJECT_NAME}.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# setting tls to allow connection to database
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf

WORKDIR /app
COPY --from=build-dev /app/out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENV ASPNETCORE_ENVIRONMENT={ENVIRONMENT_NAME}

ENTRYPOINT ["dotnet", "{PROJECT_NAME}.dll"]

