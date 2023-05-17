using Core.Models;
using MediatR;

namespace API.Application.Queries.Models.Common;

public class GetGenericQuery<TModel, TEntity> : IRequest<IReadOnlyList<TModel>>
    // where TModel : BaseEntity
    // where TEntity : BaseEntity
{
    // Полезные свойства или параметры запроса могут быть добавлены сюда
}

