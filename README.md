# TCC

buildar um docker file. Executar na raiz da solution

```
docker build -t notificacoes -f "src\BoaEntrega.GSL.Notificacoes\Dockerfile" .
```

subir o docker compose
```
docker-compose up -d --build
```

deletar todas imagens
```
docker rmi $(docker images --format "{{.Repository}}:{{.Tag}}"|findstr "boaentrega") 
```