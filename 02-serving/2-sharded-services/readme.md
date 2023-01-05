```bash

kubectl create configmap shared-twem-config --from-file=./shared-nutcracker.yaml

kubectl apply -f memcached-service.yaml
kubectl apply -f memcached-shards.yaml
kubectl apply -f shard-router-service.yaml
kubectl apply -f shared-twemproxy-deploy.yaml

```
