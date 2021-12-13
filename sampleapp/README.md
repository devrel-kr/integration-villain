# Sample App #

AKS에 올라가는 샘플 애플리케이션을 저장하는 디렉토리입니다
아래 실행은 [Azure Cloud Shell](https://shell.azure.com)에서 실행할 수 있습니다. PowerShell 환경에서 쉘 스크립트를 실행시에는 `bash` 를 실행하여 사용합니다.
## MSA app on AKS

1. AKS 리소스 생성 (Application Routing 활성화)
- ARM 템플릿 참고 (폴더: `templates`)
- 템플릿에서 사용한 *parameter*
  - AKS 리소스 이름: `aks-for-msa`
  - Kubernetes 버전: `1.20.9` (현재 안정 버전)
- 템플릿에 나오지 않으나 설정한 *parameter*
  - VM 사이즈: 데모 환경에서는 Production 용이 아니므로 `Standard_B4ms` 를 사용

2. AKS credential을 가져와 kubectl 사용 가능하도록 준비
- `[RESOURCE_GROUP_NAME]` 을 리소스 그룹 명으로, `[RESOURCE_NAME_AKS]` 를 AKS 리소스 명으로 변경 
```
$ az aks get-credentials -g [RESOURCE_GROUP_NAME] -n [RESOURCE_NAME_AKS]
```

3. Sock-shop 앱을 AKS에 배포
```
$ curl -O https://raw.githubusercontent.com/microservices-demo/microservices-demo/master/deploy/kubernetes/complete-demo.yaml
$ kubectl create namespace sock-shop
$ kubectl apply -f complete-demo.yaml
```

4. HTTP Application Routing을 사용해 sock-shop 앱을 웹 브라우저에서 확인
- `[RESOURCE_GROUP_NAME]` 을 리소스 그룹 명으로, `[RESOURCE_NAME_AKS]` 를 AKS 리소스 명으로 변경 

```bash
$ HTTP_APP_ROUTING_HOST=$(az aks show -g [RESOURCE_GROUP_NAME] -n [RESOURCE_NAME_AKS] --query addonProfiles.httpApplicationRouting.config.HTTPApplicationRoutingZoneName -o tsv)
cat aks-expose-app-routing.yaml | sed -e "s/CLUSTER_SPECIFIC_DNS_ZONE/$HTTP_APP_ROUTING_HOST/" | kubectl apply -f -
```

5. sock-shop 앱을 웹 브라우저에서 확인
- 아래 명령어를 통해 얻은 URL로 접속해봅니다. Sock-shop MSA 앱을 확인할 수 있습니다.
```bash
cat aks-expose-app-routing.yaml | sed -e "s/CLUSTER_SPECIFIC_DNS_ZONE/$HTTP_APP_ROUTING_HOST/" | grep host | awk '{print "http://"$3}'
```

6. 다음 작업은 이후 `monitorapp`에서 API 액세스할 때 사용하기 위한 토큰 값을 얻는 과정입니다. 모니터링에 사용할 쿠버네티스 SA 계정을 만들고 role-binding을 수행합니다.
```bash
NICK=villain
kubectl -n sock-shop create sa $NICK

cat aks-role-binding.yaml | sed -e "s/NICK/$NICK/" |kubectl create -f -
TOKEN=`kubectl get secrets -n sock-shop $(kubectl get sa -n sock-shop $NICK -o jsonpath="{.secrets[0].name}") -o jsonpath="{.data.token}" | base64 -d`
echo $TOKEN
```
