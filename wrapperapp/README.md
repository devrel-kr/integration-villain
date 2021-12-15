# Wrapper App #

팀즈에 사용하는 모니터링용 대시보드 앱을 배포합니다.


## 리포지토리 포크 ##

모니터링용 대시보드 앱은 [애저 정적 웹 앱](https://docs.microsoft.com/ko-kr/azure/static-web-apps/overview?WT.mc_id=dotnet-52121-juyoo&ocid=AID3035186)을 사용합니다. 따라서, 앱을 배포하려면 우선 자신의 리포지토리로 포크를 해야 합니다.


## 대시보드 앱 배포 ##

1. 우선 GitHub에 아래 명령어와 같이 GitHub CLI를 이용해 로그인 합니다.

    ```bash
    gh auth login
    ```

2. 아래 애저 CLI 명령어를 이용해 앱을 배포해 보세요. 배포에는 [애저 Bicep](https://docs.microsoft.com/ko-kr/azure/azure-resource-manager/bicep/overview?WT.mc_id=dotnet-52121-juyoo&ocid=AID3035186) 파일을 사용합니다.

    ```bash
    ASWA_NAME=<애저 정적 웹 앱 이름>
    ASWA_REPOSITORY_URL=<애저 정적 웹 앱 리포지토리 URL>
    ASWA_REPOSITORY_TOKEN=$(cat ~/.config/gh/hosts.yml| yq -r '."github.com".oauth_token')

    az deployment group create \
        -g $RESOURCE_GROUP \
        -n dashboard \
        --template-uri https://raw.githubusercontent.com/devrel-kr/integration-villain/main/wrapperapp/templates/template.bicep \
        --parameters name=$ASWA_NAME \
        --parameters location=$LOCATION \
        --parameters repositoryUrl=$ASWA_REPOSITORY_URL \
        --parameters repositoryToken=$ASWA_REPOSITORY_TOKEN \
        --verbose
    ```

> 만약 `yq` 명령어가 동작하지 않으면 아래 작업을 먼저 수행해 주세요.
> 1. `pip3 install yq` 명령어로 `yq` 설치
> 2. `yq` 설치 후 `export PATH=$PATH:$HOME/.local/bin` 명령으로 경로 등록해 주세요.

