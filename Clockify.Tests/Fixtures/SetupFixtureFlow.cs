using NUnit.Framework;

namespace Clockify.Tests.Fixtures; 

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