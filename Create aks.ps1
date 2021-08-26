az login
az account set --subscription "New gift"

az group create --name daprpubsubachraf  --location northeurope

az aks create --resource-group daprpubsubachraf --name myAKSClusterpubsubdemo --node-count 1 --enable-addons monitoring --generate-ssh-keys

# stop AKS --- https://docs.microsoft.com/en-us/azure/aks/start-stop-cluster
az aks stop --name myAKSClusterpubsubdemo --resource-group daprpubsubachraf
az aks show --name myAKSClusterpubsubdemo --resource-group daprpubsubachraf

# start AKS --- https://docs.microsoft.com/en-us/azure/aks/start-stop-cluster 
az aks start --name myAKSClusterpubsubdemo --resource-group daprpubsubachraf
az aks show --name myAKSClusterpubsubdemo --resource-group daprpubsubachraf

# kubectl CLI
az aks install-cli

# access AKS
az aks get-credentials --name myAKSClusterpubsubdemo --resource-group daprpubsubachraf
# query AKS
kubectl get nodes