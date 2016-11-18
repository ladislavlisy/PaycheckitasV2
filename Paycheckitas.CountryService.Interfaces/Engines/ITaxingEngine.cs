namespace Paycheckitas.CountryService.Interfaces
{
	public interface ITaxingEngine : IGeneralEngine, IPeriodTaxingGuides
	{
		ITaxingGuides Guides ();
	}
}