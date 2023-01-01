using Specification.Domain.Notifications;
using Specification.Domain.Specifications;
using Specification.Domain.Entities;

namespace Specification.Domain.ValidationRules
{
    public class PhoneValidationRule: ISpecification<Staff>
    {
        public bool IsSatisfiedBy(Staff staff)
        {
            bool isSatisfied = !string.IsNullOrEmpty(staff.GetPhone());

             if (!isSatisfied) 
                NotificationPublisher.OnRaiseNotificationEvent(new NotificationEventArgs("This is Invalid Phone message"));
            
            return isSatisfied;
        }
    }
}
