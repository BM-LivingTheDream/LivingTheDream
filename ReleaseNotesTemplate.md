# RELEASENOTES

**Release Name** :  ${releaseDetails.releaseDefinition.name}
**Release Number** : ${releaseDetails.name}
**Release Completed** : ${releaseDetails.modifiedOn}
**Compared Release Number** : ${compareReleaseDetails.name}
**Build Number** - $(Build.BuildNumber) 
**Build Id** - $(Build.DefinitionId) 
**Build Source Branch** - $(Build.SourceBranchName) 
**Build Type** - $(Build.Type) 

### DESCRIPTION
@@WILOOP:RN-OVERVIEW@@
${widetail.fields['System.Description']}
@@WILOOP:RN-OVERVIEW@@

### FEATURES
@@WILOOP:RN-FEATURES@@
${widetail.fields['System.Description']}
@@WILOOP:RN-FEATURES@@

### Associated work items
@@WILOOP@@
* **${widetail.fields['System.WorkItemType']} #${widetail.id}** Assigned by: ${widetail.fields['System.AssignedTo']} - ${widetail.fields['System.Title']}
@@WILOOP@@

### Associated commits
@@CSLOOP@@
* **ID ${csdetail.id} ** ${csdetail.message}
@@CSLOOP@@
