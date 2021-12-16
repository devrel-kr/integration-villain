# Teams App #

팀즈에 통합하기 위한 앱을 저장하는 디렉토리입니다

1. Teams App이란? 
    * Microsoft Teams는 Microsoft App과 3rd-party App 외에도 사용자가 직접 App을 제작하여 Teams에 업로드할 수 있는 기능을 제공합니다.
    * Teams 내 Tab, Notification, Meeting extension, Bot, Messaging extension 등 다양한 개발 가능 영역이 있으며, 이를 손쉽게 개발할 수 있도록 Teams Toolkit 을 제공합니다.
    ![image](https://user-images.githubusercontent.com/46836149/146118291-5c3fb001-97e9-44ed-a0c4-364ecfb732ca.png)
    * 구현하고자 하는 App의 형태에 따라, Teams 내의 'App Studio' app을 사용하여 더 빠르고 간단하게도 Teams App 제작이 가능합니다.


[Step-by-step]

**(관리자 사전 설정) **
1. Admin 센터
    * 계정 로그인
    * 좌측 메뉴 > Teams apps > Setup policies 클릭
        - Upload custom apps: **On** / User pinning: **On**
        <img width="1249" alt="image" src="https://user-images.githubusercontent.com/46836149/146119597-2c5060aa-eeed-4d45-b7e4-ccad1ab92834.png">

 **(App 제작)**
1. 만들고자 하는 App: 대시보드 앱을 Teams에 Embed 하는 형태를 실습 예정 
2. Teams App Studio
    * 사용자 또는 관리자 계정으로 Teams 로그인
    * 좌측 side에 ... 클릭 > App Studio 검색 (2022년 1월 종료 예정; Developer portal로 이전 예정:dev.teams.microsoft.com) 
    * 좌측에 '+ Create a new app' 클릭 > 
    * Details 탭 > App details 입력
        - App names(short & full name) : 'Dashboard App'입력
        - Identification: (App ID) Generate 클릭 / (Package Name) 'dashboard-app' 입력 / (Version) 1.0.0
        - Descriptions, Developer information, Partner information, App URLs
        - Branding: 원하는 앱 이미지 Update 가능
   * Capabilities 탭 > Tabs > Add a personal tab
        - Name: Tab name 으로 'Dashboard' 입력
        - Entity ID: 'dashboardapp'입력
        - Content URL: Azure web app URL 입력
   * Finish 탭 
        - App Manifest (preview) 로 입력한 내용으로 자동 작성된 것 확인
        - Test and distribute: Download zip. file

3. Teams App Upload
   * 좌측 하단 Apps 클릭 > Upload a custom app > Upload for my org > 관리자 approval

**(App Publish) **
1. Teams에 제작한 Custom App을 업로드하기 위해서는 먼저 다음과 같은 Admin 설정이 필요합니다. 
    * **Admin portal site:** admin.teams.microsoft.com
    * 해당 사이트에서 admin 설정을 위해서는 Teams Admin 권한이 필요합니다. 

2. Admin 센터 
    * Admin 계정 로그인
    * 좌측 메뉴 > Teams apps > Manage apps 클릭
        - 우측 search box에 제작한 App name 입력 > Publishing status 확인 및 Allow 클릭 > App Status 변경된 것 확인
        <img width="1249" alt="image" src="https://user-images.githubusercontent.com/46836149/146119663-7829737b-88f0-4329-987e-ea4c3f1a6999.png">
