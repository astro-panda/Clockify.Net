using Clockify.Tests.Fixtures;
using NUnit.Framework;

/// <summary>
/// If class doesn't have a namespace it is a global Setup class. NUnit.
/// </summary>
[SetUpFixture]
public class SetupFixtureFlow {

	[OneTimeSetUp]
	public void Setup() {
		EnvironmentFixture.Setup();
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		EnvironmentFixture.TearDown();
	}
}
