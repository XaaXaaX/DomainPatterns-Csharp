using Specification.Domain.Specifications;
using Specification.Domain.Entities;

namespace Specification.Domain.ValidationRules
{
    public sealed class StaffValidationRule: ISpecification<Staff>
    {
        public readonly NameValidationRule NameValidationRule = new NameValidationRule();
        public readonly PhoneValidationRule PhoneValidationRule = new PhoneValidationRule();

        public bool IsSatisfiedBy(Staff model) 
            => NameValidationRule
                .XAnd(PhoneValidationRule)
                .IsSatisfiedBy(model);
    }
}
