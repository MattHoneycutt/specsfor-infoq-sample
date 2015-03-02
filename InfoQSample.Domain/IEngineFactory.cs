namespace InfoQSample.Domain
{
	public interface IEngineFactory
	{
		Engine GetEngine(string engineType);
	}
}