namespace Paycheckitas.CountryService.Interfaces
{
	public interface IHealthEngine : IGeneralEngine, IPeriodHealthGuides
	{
		IHealthGuides Guides ();
	}
}