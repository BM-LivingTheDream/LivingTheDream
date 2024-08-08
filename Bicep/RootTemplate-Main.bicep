@description('The name for the App Services hosting plan that will contain the web site. Default of FabrikamHP')
@minLength(1)
param hostingPlanName string = 'FabrikamHP'

@description('Describes plan\'s pricing tier and instance size. Check details at https://azure.microsoft.com/en-us/pricing/details/app-service/')
@allowed([
  'F1'
  'D1'
  'B1'
  'B2'
  'B3'
  'S1'
  'S2'
  'S3'
  'P1'
  'P2'
  'P3'
  'P4'
])
param hostingPlanSku string = 'F1'

@description('Describes plan\'s instance count')
@minValue(1)
param hostingPlanCapacity int = 1
param webSiteName string = 'FabrikamWeb'

@description('The name of the Azure SQL database server. Default of fabrikamsql')
param sqlserverName string = 'fabrikamsql'
param sqlServerAdminLogin string

@secure()
param sqlServerAdminPassword string

@description('The name of the Azure SQL database. Default of FabrikamDB1')
param databaseName string = 'FabrikamDB1'
param collation string = 'SQL_Latin1_General_CP1_CI_AS'

@allowed([
  'Basic'
  'Standard'
  'Premium'
])
param edition string = 'Standard'
param maxSizeBytes string = '1073741824'

@description('Describes the performance level for Edition')
@allowed([
  'Basic'
  'S0'
  'S1'
  'S2'
  'P1'
  'P2'
  'P3'
])
param requestedServiceObjectiveName string = 'S0'

@description('Build version for Resource Tag')
param VersionTag string = '1-0-0-0'

@description('Date for resource tag')
param DeploymentDate string = '1900-01-01'

@description('Environment Purpose')
param EnvironmentTag string = 'dev'

resource sqlserver 'Microsoft.Sql/servers@2021-02-01-preview' = {
  name: sqlserverName
  location: resourceGroup().location
  tags: {
    displayName: 'SqlServer'
    version: VersionTag
    deploymentDate: DeploymentDate
    environmentName: EnvironmentTag
  }
  properties: {
    administratorLogin: sqlServerAdminLogin
    administratorLoginPassword: sqlServerAdminPassword
  }
}

resource sqlserverName_database 'Microsoft.Sql/servers/databases@2021-02-01-preview' = {
  parent: sqlserver
  name: '${databaseName}'
  location: resourceGroup().location
  tags: {
    displayName: 'Database'
    version: VersionTag
    deploymentDate: DeploymentDate
    environmentName: EnvironmentTag
  }
  properties: {
    edition: edition
    collation: collation
    maxSizeBytes: maxSizeBytes
    requestedServiceObjectiveName: requestedServiceObjectiveName
  }
}

resource sqlserverName_AllowAllWindowsAzureIps 'Microsoft.Sql/servers/firewallrules@2021-02-01-preview' = {
  parent: sqlserver
  location: resourceGroup().location
  name: 'AllowAllWindowsAzureIps'
  properties: {
    endIpAddress: '0.0.0.0'
    startIpAddress: '0.0.0.0'
  }
}

resource hostingPlan 'Microsoft.Web/serverfarms@2015-08-01' = {
  name: hostingPlanName
  location: resourceGroup().location
  tags: {
    displayName: 'HostingPlan'
    version: VersionTag
    deploymentDate: DeploymentDate
    environmentName: EnvironmentTag
  }
  sku: {
    name: hostingPlanSku
    capacity: hostingPlanCapacity
  }
  properties: {
    name: hostingPlanName
  }
}

resource webSite 'Microsoft.Web/sites@2015-08-01' = {
  name: webSiteName
  location: resourceGroup().location
  tags: {
    'hidden-related:${resourceGroup().id}/providers/Microsoft.Web/serverfarms/${hostingPlanName}': 'empty'
    displayName: 'Website'
    version: VersionTag
    deploymentDate: DeploymentDate
    environmentName: EnvironmentTag
  }
  properties: {
    name: webSiteName
    serverFarmId: hostingPlan.id
  }
}

resource webSiteName_connectionstrings 'Microsoft.Web/sites/config@2015-08-01' = {
  parent: webSite
  name: 'connectionstrings'
  properties: {
    DefaultConnection: {
      value: 'Data Source=tcp:${sqlserver.properties.fullyQualifiedDomainName},1433;Initial Catalog=${databaseName};User Id=${sqlServerAdminLogin}@${sqlserverName};Password=${sqlServerAdminPassword};'
      type: 'SQLServer'
    }
  }
}

output WebsiteHostName string = webSite.properties.hostNames[0]
output SQLServerFQDN string = sqlserver.properties.fullyQualifiedDomainName
output WebCreds object = list(
  '${resourceGroup().id}/providers/Microsoft.Web/sites/${webSiteName}/config/publishingcredentials/',
  '2015-08-01'
)
