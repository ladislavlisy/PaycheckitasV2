namespace Paycheckitas.CountryService.Interfaces
{
	public interface ISocialEngine : IGeneralEngine, IPeriodSocialGuides
	{
		ISocialGuides Guides ();
	}
}