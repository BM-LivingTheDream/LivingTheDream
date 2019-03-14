[[_TOC_]]

# Release Notes
[Link to release ${releaseDetails.name}](${releaseDetails.release._links.web.href})
[Link to artefact ${releaseDetails.artifacts[0].alias}](${releaseDetails.artifacts[0].definitionReference.artifactSourceVersionUrl})
[Link to artefact ${releaseDetails.artifacts[1].alias}](${releaseDetails.artifacts[1].definitionReference.artifactSourceVersionUrl})

| --- | --- |
| Date of release | ${releaseDetails.artifacts[1].CreatedOn} |
| Release Definition | [${releaseDetails.releaseDefinition.name}](${releaseDetails.releaseDefinition._links.web.href}) |
| ${releaseDetails.artifacts[0].alias} Version | ${releaseDetails.artifacts[0].definitionReference.version.name} |
| ${releaseDetails.artifacts[1].alias} Version | ${releaseDetails.artifacts[1].definitionReference.version.name} |


### Associated work items
@@WILOOP@@
* #${widetail.id}
@@WILOOP@@

### Associated commits
@@CSLOOP@@
* **ID ${csdetail.id} ** ${csdetail.message}
@@CSLOOP@@