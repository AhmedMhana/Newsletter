using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subscriber
    {
        public Guid Id { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailIsRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidEmailAddress")]
        public string Email { get; set; }

        [Display(Name = "HeardAboutUs", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "HeardFromResourcesIsRequired")]
        public HeardFromResources HeardFrom { get; set; }

        [Display(Name = "ReasonForSignup", ResourceType = typeof(Resources.Resources))]
        public string ReasonForSignup { get; set; }
    }
}
