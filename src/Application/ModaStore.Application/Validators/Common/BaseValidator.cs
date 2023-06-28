using FluentValidation;

namespace ModaStore.Application.Validators.Common;

// public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
// {
//
//     protected BaseValidator(IEnumerable<IValidatorConsumer<T>> validators)
//     {
//         PostInitialize(validators);
//     }
//
//     private void PostInitialize(IEnumerable<IValidatorConsumer<T>> validators)
//     {
//         foreach (var item in validators)
//         {
//             item.AddRules(this);
//         }
//
//     }
//
// }