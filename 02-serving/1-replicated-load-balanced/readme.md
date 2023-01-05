```
kubectl create secret generic nginx-ssl --from-file=./nginx.crt --from-file=./nginx.key --from-file=./dhparam.pem

kubectl create configmap nginx-conf --from-file=./nginx.conf

kubectl create configmap varnish-config --from-file=default.vcl

https://localhost/dictionary/LOMBARD

```
