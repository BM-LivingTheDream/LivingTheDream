# Release Notes

| | Details |
| --- | --- |
| Build | [{{buildDetails.buildNumber}}]({{buildDetails._links.web.href}}) |
| Branch | {{buildDetails.sourceBranch}} |
| Tags | {{buildDetails.tags}} |
| Started | {{buildDetails.startTime}} |


## Pull Requests

| ID | Created By |Title |
| --- | --- | --- |
{{#forEach pullRequests}}
| [{{this.pullRequestId}}]({{replace (replace this.url "_apis/git/repositories" "_git") "pullRequests" "pullRequest"}}) | {{this.createdBy.displayName}} | {{this.title}} |
{{/forEach}}