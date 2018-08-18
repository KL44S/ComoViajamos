sudo dotnet publish -c Release
sudo chmod 777 -R ./1.API/bin/Release
sudo echo 'FROM microsoft/aspnetcore
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet 1.API.dll' > ./1.API/bin/Release/netcoreapp2.0/publish/Dockerfile
sudo docker build -t como-viajamos ./1.API/bin/Release/netcoreapp2.0/publish
sudo heroku login
sudo heroku container:login
sudo docker tag como-viajamos registry.heroku.com/como-viajamos/web
sudo docker push registry.heroku.com/como-viajamos/web
sudo heroku container:release web -a como-viajamos
