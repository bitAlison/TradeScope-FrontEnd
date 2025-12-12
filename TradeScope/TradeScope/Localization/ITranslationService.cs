namespace TradeScope.Localization
{
    public interface ITranslationService
    {
        string this[string key] { get; }
    }
}
