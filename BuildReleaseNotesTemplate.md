## Build {{buildDetails.buildNumber}}
* **Branch**: {{buildDetails.sourceBranch}}
* **Tags**: {{buildDetails.tags}}
* **Completed**: {{buildDetails.finishTime}}
* **Previous Build**: {{compareBuildDetails.buildNumber}}

## Associated Pull Requests ({{pullRequests.length}})
{{#forEach pullRequests}}
* **[{{this.pullRequestId}}]({{replace (replace this.url "_apis/git/repositories" "_git") "pullRequests" "pullRequest"}})** {{this.title}}
* Associated Work Items
{{#forEach this.associatedWorkitems}}
   {{#with (lookup_a_work_item ../../relatedWorkItems this.url)}}
    - [{{this.id}}]({{replace this.url "_apis/wit/workItems" "_workitems/edit"}}) - {{lookup this.fields 'System.Title'}} 
   {{/with}}
{{/forEach}}
* Associated Commits (this includes commits on the PR source branch not associated directly with the build)
{{#forEach this.associatedCommits}}
    - [{{this.commitId}}]({{this.remoteUrl}}) -  {{this.comment}}
{{/forEach}}
{{/forEach}}