param name string
param location string
param repositoryUrl string = 'https://github.com/devrel-kr/integration-villain'

@secure()
param repositoryToken string

resource symbolicname 'Microsoft.Web/staticSites@2021-02-01' = {
  name: name
  location: location
  sku: {
    name: 'Free'
    tier: 'Free'
  }
  properties: {
    repositoryUrl: repositoryUrl
    repositoryToken: repositoryToken
    branch: 'main'
    allowConfigFileUpdates: true
    buildProperties: {
      appLocation: 'wrapperapp/Wrapper.WasmApp'
      apiLocation: 'wrapperapp/Wrapper.ApiApp'
      appArtifactLocation: 'wwwroot'
    }
    stagingEnvironmentPolicy: 'Enabled'
  }
}
