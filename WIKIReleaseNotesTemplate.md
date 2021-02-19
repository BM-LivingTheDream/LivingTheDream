[[_TOC_]]

# Release Notes
## Links to Release and Artefacts
[Link to release ${buildDetails.name}]({{buildDetails._links.web.href}})

## Release Details

| | Details |
| --- | --- |
| Date of release | {{buildDetails.createdOn}} |
| Release Definition | [{{buildDetails.buildNumber}}]({{buildDetails._links.web.href}}) |


### Associated work items
| Type | ID | Assigned To | Title |
| --- | --- | --- | --- |
{{#forEach this.workItems}}
| {{lookup this.fields 'System.WorkItemType'}} | {{this.id}} | {{lookup this.fields 'System.AssignedTo'}} | {{lookup this.fields 'System.Title'}}|
{{/forEach}}

### Associated commits
| Commit ID | Comment |
| --- | --- |
{{#forEach this.commits}}
| {{this.id}} | {{this.message}} |
{{/forEach}}