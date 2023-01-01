using Specification.Domain.ValidationRules;
using Specification.Domain.Entities;

namespace Specification.Domain;
public class StaffValidator : Validator<Staff>
{
    public StaffValidator()
        : base(new StaffValidationRule()) {}
}
