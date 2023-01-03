```bash
kubectl create configmap --from-file=nutcracker.yaml twem-config
```

```bash
redis-cli -h localhost -p 6379 GET User
```
