[![https://www.nuget.org/packages/Clockify.Net/](https://img.shields.io/nuget/v/Clockify.Net)](https://www.nuget.org/packages/Clockify.Net/)
[![GitHub issues](https://img.shields.io/github/issues/Morasiu/Clockify.Net)](https://GitHub.com/Morasiu/Clockify.Net/issues/)
[![GitHub license](https://img.shields.io/github/license/Morasiu/Clockify.Net.svg)](https://github.com/Morasiu/Clockify.Net/blob/master/LICENSE)
<!--[![Build Status](https://travis-ci.org/Morasiu/Clockify.Net.svg?branch=master)](https://travis-ci.org/Morasiu/Clockify.Net) -->

# <img src="https://clockify.me/assets/images/clockify-logo.png" width="25"> Clockify.Net
Clockify C# Client. 

Made as .Net Standard 2.0 library.

Stable API docs:
> Every endpoint from that url is implemented.

https://clockify.me/developers-api

EXPERIMENTAL API

https://clockify.github.io/clockify_api_docs/

Also check [CHANGELOG](CHANGELOG.md).

> If you like this project, give it a star ⭐. It really motives me to work on it.

## Usage

### 1. Add Nuget package from [here](https://www.nuget.org/packages/Clockify.Net/).

### 2. Get your Clockify API Key.

> See [API docs](https://clockify.me/developers-api) for instruction about how to get **Clockify API Key**.

### 3. Create your client.

Recommended:
```csharp
// This will use environment variable CAPI_KEY as your API key input.
var clockify = new ClockifyClient();
var response = await clockify.GetWorkspacesAsync();
```

or much simpler

```csharp
var clockify = new ClockifyClient("myClockifyApiKey");
var response = await clockify.GetWorkspacesAsync();
```

## 💻 Development

Do you want to help? Great!

See [CONTRIBUTING](https://github.com/Morasiu/Clockify.Net/blob/master/Docs/CONTRIBUTING.md) 👍

Also check our [Project tab](https://github.com/Morasiu/Clockify.Net/projects/) ✅ and pick a task!

## Authors

* Morasiu (morasiu2@gmail.com)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
