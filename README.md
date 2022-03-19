[![https://www.nuget.org/packages/Clockify.Net/](https://img.shields.io/nuget/v/Clockify.Net)](https://www.nuget.org/packages/Clockify.Net/)
[![GitHub issues](https://img.shields.io/github/issues/Morasiu/Clockify.Net)](https://GitHub.com/Morasiu/Clockify.Net/issues/)
[![GitHub license](https://img.shields.io/github/license/Morasiu/Clockify.Net.svg)](https://github.com/Morasiu/Clockify.Net/blob/master/LICENSE)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=clockify.net&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=clockify.net)

# <img src="https://clockify.me/assets/images/clockify-logo.png" width="25"> Clockify.Net
Clockify C# Client. 

Made as .Net Standard 2.0 library.

Stable API docs:
> Every endpoint from that url is implemented.

https://clockify.me/developers-api

EXPERIMENTAL API

https://clockify.github.io/clockify_api_docs/

Also check [CHANGELOG](CHANGELOG.md).

> ⚠ Breaking changes in version 2.0.0. See [CHANGELOG](CHANGELOG.md).

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

<a href="https://www.buymeacoffee.com/morasiu" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
