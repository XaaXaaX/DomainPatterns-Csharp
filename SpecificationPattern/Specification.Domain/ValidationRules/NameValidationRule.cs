using Specification.Domain.Notifications;
using Specification.Domain.Specifications;
using Specification.Domain.Entities;

namespace Specification.Domain.ValidationRules
{
    public class NameValidationRule: ISpecification<Staff>
    {
        public bool IsSatisfiedBy(Staff staff)
        {
            bool isSatisfied  = !string.IsNullOrEmpty(staff.GetName());
    
            if (!isSatisfied) 
                NotificationPublisher.OnRaiseNotificationEvent(new NotificationEventArgs("This is invalid Name message"));
            
            return isSatisfied;
        }
    }
}
