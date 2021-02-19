[[_TOC_]]

# Release Notes
## Release Details
| | Details |
| --- | --- |
| Date of release | {{buildDetails.startTime}} |
| Release Definition | [{{buildDetails.buildNumber}}]({{buildDetails._links.web.href}}) |

<br/>

## Associated work items
| Type | ID | Assigned To | Title |
| --- | --- | --- | --- |
{{#forEach this.workItems}}
| {{lookup this.fields 'System.WorkItemType'}} | [{{this.id}}]({{this._links.html.href}}) | {{#with (lookup this.fields 'System.AssignedTo')}} {{displayName}} {{/with}} | {{lookup this.fields 'System.Title'}}|
{{/forEach}}

<br/>

## Associated commits
| Commit ID | Comment |
| --- | --- |
{{#forEach this.commits}}
| [{{truncate this.id  7 }}]({{replace (replace this.location "_apis/git/repositories" "_git") "/commits/" "/commit/"}}) | {{get_only_message_firstline this.message}} |
{{/forEach}}