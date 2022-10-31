# dependabot-slack-integration

[![Visual Studio - 2019](https://img.shields.io/static/v1?label=Visual+Studio&message=2019&color=%235C2D91&logo=visual+studio&logoColor=%23fffff)](https://) [![Slack - slack](https://img.shields.io/static/v1?label=Slack&message=slack&color=%23E01E5A&logo=slack&logoColor=%23fffff)](https://)

## Introduction

This Azure Function App helps you to integrate [Dependabot alerts](https://docs.github.com/en/code-security/dependabot/dependabot-alerts/about-dependabot-alerts) to your slack channels.

## Objective

Using GitHub Webhooks, export dependabot alerts when generated to a Slack Channel

## Prerequisites

- [GitHub Webhook](https://docs.github.com/en/developers/webhooks-and-events/webhooks/creating-webhooks)
- [Azure Subscription](https://azure.microsoft.com/en-in/free/)
- [Visual Studio with Azure Development ](https://learn.microsoft.com/en-us/dotnet/azure/configure-visual-studio) installed 
- [Incoming Webhook](https://slack.com/intl/en-in/help/articles/115005265063-Incoming-webhooks-for-Slack) for a slack channel, 

### How the integration works

When a new dependabot alert is generated, the dependabot alert webhook from GitHub is triggered sending the payload to an Azure Function App. The Function app then processes 
the recieving payload and picks the necessary information to be forwarded to the slack. The function app then constructs a new payload which is then sent to slack by using the slack incmoing webhook. 

### First steps

- Create a [GitHub Webhook](https://docs.github.com/en/developers/webhooks-and-events/webhooks/creating-webhooks), choosing the event Dependabot alert
- Create a [Incoming Webhook](https://slack.com/intl/en-in/help/articles/115005265063-Incoming-webhooks-for-Slack) for a slack channel, to where you want to push the alerts. 
- Look [here](https://learn.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio?tabs=in-process) for publishing a C# function app using visual studio. 

### Installation & Running your App

For further installation instructions, please see [here](https://github.com/CanarysAutomations/dependabot-slack-integration/wiki)
