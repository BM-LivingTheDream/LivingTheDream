[[_TOC_]]

# Release Notes
## Links to Release and Artefacts
[Link to release ${releaseDetails.name}](${releaseDetails._links.web.href})
[Link to artefact ${releaseDetails.artifacts[0].alias}](${releaseDetails.artifacts[0].definitionReference.artifactSourceVersionUrl.id})
[Link to artefact ${releaseDetails.artifacts[1].alias}](${releaseDetails.artifacts[1].definitionReference.artifactSourceVersionUrl.id})

## Release Details

| | Details |
| --- | --- |
| Date of release | ${releaseDetails.createdOn} |
| Release Definition | [${releaseDetails.releaseDefinition.name}](${releaseDetails.releaseDefinition._links.web.href}) |
| ${releaseDetails.artifacts[0].alias} Version | ${releaseDetails.artifacts[0].definitionReference.version.name} |
| ${releaseDetails.artifacts[1].alias} Version | ${releaseDetails.artifacts[1].definitionReference.version.name} |


### Associated work items
| Type | ID | Assigned To | Title |
| --- | --- | --- | --- |
@@WILOOP@@
| ${widetail.fields['System.WorkItemType']} | ${widetail.id} | ${widetail.fields['System.AssignedTo']} | ${widetail.fields['System.Title']} |
@@WILOOP@@

### Associated commits
| Commit ID | Comment |
| --- | --- |
@@CSLOOP@@
| ${csdetail.commitId} | ${csdetail.comment} |
@@CSLOOP@@