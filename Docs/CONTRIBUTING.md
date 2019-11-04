# Contributing to Termgine

👍🎉 First off, thanks for taking the time to contribute! 🎉👍

## How can you contribute?

* 📖 Contributte to our [Wiki](https://github.com/Morasiu/Clockify.Net/wiki).
* ✅ Go on our [Project tab](https://github.com/Morasiu/Clockify.Net/projects) and pick some tasks.
* 🎤 Spread the news. Share our project!

## Developing 💻

> All new features must have tests.
### 1. **BEFORE YOU START**

To setup your testing environment:

1. Set environment variable `CAPI_KEY` to you Clockify API key.

or

1. Copy `.runsettings.default` to `.runsettings`
    > `.runsettings` is in `.gitignore` so don't worry
1. Change `your_clockify_api_key` to your own Clockify API key. See [API docs](https://clockify.me/developers-api) for instruction.
1. Set `.runsettings` as your test settings file.

> Test naming convention `MethodName_ShouldDoSomething()`

### 2. Writing actual code

> We use [`git flow`](https://jeffkreeftmeijer.com/git-flow/) for git management.

1. Pick some task.
1. Make a `feature` branch
1. Code, code, code.
    * Remember about **tests**
4. Make a `Pull Request`. 