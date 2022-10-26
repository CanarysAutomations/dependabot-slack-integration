# dependabot-slack-integration

## Objective

Using GitHub Webhooks, export dependabot alerts when generated to a Slack Channel

## Pre-requisites

- GitHub Webhooks
- Azure Subscription
- Visual Studio with Azure Development Workload Installed
- An incoming webhook from a Slack Channel

### How the integration works

When a new dependabot alert is generated, the dependabot alert webhook from GitHub is triggered sending the payload to a Azure Function App. The Function app then processes 
the recieving payload and picks the necessary information to be forwarded to slack. The function app then constructs a new payload which is then sent to slack by using the slack webhook url.

### First steps

- Create a GitHub Webhook, choosing the event Dependabot alert. For more details check [here](https://docs.github.com/en/developers/webhooks-and-events/webhooks/creating-webhooks)
- Create a Incoming Webhook for a slack channel, to where you want to push the alerts. For more details check [here](https://slack.com/intl/en-in/help/articles/115005265063-Incoming-webhooks-for-Slack)
- For more details on publishing a C# function app using visual studio, please check [here](https://learn.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio?tabs=in-process)
- For further installation instructions, please see [here](https://github.com/CanarysAutomations/dependabot-slack-integration/wiki)
