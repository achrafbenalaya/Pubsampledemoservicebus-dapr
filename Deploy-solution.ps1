#deploy pusb sub
kubectl apply -f .\componments\orderpubsub.yaml -n dapr-system


#deploy apps
kubectl apply -f .\deployservices\deploymvc.yaml -n dapr-system

kubectl apply -f .\deployservices\pubsubapi.yaml -n dapr-system



