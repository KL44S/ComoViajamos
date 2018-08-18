sudo dotnet publish -c Release
sudo chmod 777 -R ./ComoViajamos/bin/Release
sudo echo 'FROM microsoft/aspnetcore
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet 1.ComoViajamos.dll' > ./ComoViajamos/bin/Release/netcoreapp2.1/publish/Dockerfile
sudo docker build -t como-viajamos ./ComoViajamos/bin/Release/netcoreapp2.1/publish
sudo heroku login
sudo heroku container:login
sudo docker tag como-viajamos registry.heroku.com/como-viajamos/web
sudo docker push registry.heroku.com/como-viajamos/web
sudo heroku container:release web -a como-viajamos
