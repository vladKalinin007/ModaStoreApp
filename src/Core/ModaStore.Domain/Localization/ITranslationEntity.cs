using ModaStore.Domain.Models.Localization;

namespace ModaStore.Domain.Localization;

public interface ITranslationEntity
{
    IList<TranslationEntity> Locales { get; set; }
}