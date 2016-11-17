namespace Paycheckitas.CountryService.Interfaces
{
	public interface ITaxingEngine : IPeriodTaxingGuides
	{
		ITaxingGuides Guides ();
	}
}