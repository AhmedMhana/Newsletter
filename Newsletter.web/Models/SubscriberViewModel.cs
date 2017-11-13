using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsletter.web.Models
{
    public class SubscriberViewModel : Subscriber
    {
        public string HeardFromDescription { get; set; }
    }
}