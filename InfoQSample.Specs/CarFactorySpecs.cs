using InfoQSample.Domain;
using NUnit.Framework;
using Should;
using SpecsFor;
using SpecsFor.ShouldExtensions;

namespace InfoQSample.Specs
{
	public class CarFactorySpecs
	{
		public class when_creating_a_muscle_car : SpecsFor<CarFactory>
		{
			protected override void Given()
			{
				GetMockFor<IEngineFactory>()
					.Setup(x => x.GetEngine("V8"))
					.Returns(new Engine
					{
						Maker = "Acme",
						Type = "V8"
					});
			}

			private Car _car;
			protected override void When()
			{
				_car = SUT.BuildMuscleCar();
			}

			[Test]
			public void then_it_creates_a_car_with_an_eight_cylinder_engine()
			{
				_car.Engine.ShouldLookLike(() => new Engine
				{
					Maker = "Acme",
					Type = "V8"
				});
			}

			[Test]
			public void then_it_calls_the_engine_factory()
			{
				GetMockFor<IEngineFactory>()
					.Verify(x => x.GetEngine("V8"));
			}
		}
	}
}