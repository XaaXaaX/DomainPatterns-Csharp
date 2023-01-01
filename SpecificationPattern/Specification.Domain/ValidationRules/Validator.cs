using Specification.Domain.Notifications;
using Specification.Domain.Specifications;

namespace Specification.Domain;
public class Validator<T> : Notifier
{
    public readonly ISpecification<T> validationRule;
    
    public Validator(ISpecification<T> validationRule)
        => this.validationRule = validationRule;
    
    public Notification Validate(T model )
    {
        this.validationRule.IsSatisfiedBy(model);
        return Notifications;
    }
}