using Core.Models.Localization;

namespace Core.Localization;

public interface ITranslationEntity
{
    IList<TranslationEntity> Locales { get; set; }
}