# Contributing to Clockify.Net

👍🎉 First off, thanks for taking the time to contribute! 🎉👍

## How can you contribute?

* 📖 Contribute to our [Wiki](https://github.com/Morasiu/Clockify.Net/wiki).
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

#### For newcomers

Just create **pull request**.

>I really recommnend [this](https://opensource.com/article/19/7/create-pull-request-github) article.

Short instruction:
1. Fork repository.
1. Clone your forked repository.
1. Create new branch from `develop`.
    * `git checkout develop`
    * `git checkout -b feature/myFeatureName`
1. Now setup upstream using
    * `git remote add upstream https://github.com/Morasiu/Clockify.Net`
1. Now is time to code (my favorite).
1. After you done commit your changes
    * `git add .`
    * `git commit -m "Your commit message"`
1. Now go to https://github.com/Morasiu/Clockify.Net and click **Compare & pull request**.
1. Confirm creating `Create pull request`
1. DONE!


#### For developers with repository rights.

> We use [`git flow`](https://jeffkreeftmeijer.com/git-flow/) for git management.

1. Pick some task.
1. Make a `feature` branch
1. Code, code, code.
    * Remember about **tests**
4. Make a `Pull Request`. 