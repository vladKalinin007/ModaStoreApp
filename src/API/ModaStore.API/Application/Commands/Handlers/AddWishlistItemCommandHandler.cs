namespace ModaStore.API.Application.Commands.Handlers;

// public class AddWishlistItemCommandHandler : IRequestHandler<AddWishlistItemCommand, WishlistItemDto>
// {
//     private readonly StoreContext _context;
//
//     public AddWishlistItemCommandHandler(StoreContext context)
//     {
//         _context = context;
//     }
//
//     public async Task<WishlistItemDto> Handle(AddWishlistItemCommand request, CancellationToken cancellationToken)
//     {
//         // создаем новую модель для добавления в базу данных
//         var model = new WishlistItemDto
//         {
//             ProductId = request.Model.ProductId,
//             UserId = request.Model.UserId
//         };
//
//         // добавляем модель в базу данных
//         _context.WishlistItems.Add(model);
//         await _context.SaveChangesAsync(cancellationToken);
//
//         // возвращаем добавленную модель
//         return model;
//     }
// }