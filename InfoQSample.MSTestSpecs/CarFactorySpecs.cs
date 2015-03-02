using System;
using InfoQSample.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InfoQSample.MSTestSpecs
{
	//Just for illustration, here's what a spec using just Moq and MS Test would look like for the car factory.
	[TestClass]
	public class CarFactorySpecs
	{
		[TestMethod]
		public void it_calls_the_engine_factory()
		{
			var engineFactoryMock = new Mock<IEngineFactory>();

			var sut = new CarFactory(engineFactoryMock.Object);

			sut.BuildMuscleCar();

			engineFactoryMock.Verify(x => x.GetEngine("V8"));
		}

		[TestMethod]
		public void it_creates_the_right_engine_type_when_making_a_car()
		{
			var engineFactoryMock = new Mock<IEngineFactory>();
			engineFactoryMock.Setup(x => x.GetEngine("V8"))
				.Returns(new Engine
				{
					Maker = "Acme",
					Type = "V8"
				});

			var sut = new CarFactory(engineFactoryMock.Object);

			var car = sut.BuildMuscleCar();

			Assert.AreEqual(car.Engine.Maker, "Acme");
			Assert.AreEqual(car.Engine.Type, "V8");
		}
	}
}
