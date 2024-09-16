namespace Core.EAInfrastructure
{
    public interface IGoogleTranslationService
    {
        Task<string> TranslateAsync(string text, string targetLanguage);
    }
}
