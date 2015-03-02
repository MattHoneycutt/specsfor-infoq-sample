using NUnit.Framework;
using Should;
using SpecsFor;
using InfoQSample.Domain;

namespace InfoQSample.Specs
{
	public class CarSpecs
	{
		public class when_a_car_is_stopped : SpecsFor<Car>
		{
			protected override void Given()
			{
				//Given a car is running (start the car!)
				SUT.Start();
			}

			protected override void When()
			{
				//When a car is stopped
				SUT.Stop();
			}

			[Test]
			public void then_the_car_is_stopped()
			{
				SUT.IsStopped.ShouldBeTrue();
			}

			[Test]
			public void then_the_engine_is_stopped()
			{
				SUT.Engine.IsStopped.ShouldBeTrue();
			}
		}
	}
}
