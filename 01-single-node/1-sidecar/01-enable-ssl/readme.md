## Sidecar SSL Termination

```bash
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout ./nginx-selfsigned.key -out ./nginx-selfsigned.crt
sudo openssl dhparam -out ./dhparam.pem 2048

# add config and secrets to k8s

kubectl create secret generic nginx-certs-keys --from-file=./nginx.crt --from-file=./nginx.key --from-file=./dhparam.pem

kubectl create configmap nginxconfigmap --from-file=./default.conf

#create deployment and service

kubectl apply -f ./legacy-api.yml

#connect cluster to localhost

sudo kubectl port-forward service/legacy-api 443:443

```
