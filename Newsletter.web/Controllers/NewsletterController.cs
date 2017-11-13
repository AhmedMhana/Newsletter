using Newsletter.web.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Enums;
using Models.Helper;
using Models;

namespace Newsletter.web.Controllers
{
    public class NewsletterController : Controller
    {
        private ISubscriberService _subscriberService;

        public NewsletterController(ISubscriberService subscriberService)
        {
            this._subscriberService = subscriberService;
        }
        // GET: Newsletter
        [HttpGet]
        public ActionResult SignUp()
        {
            ViewData["HeardFromResourcesList"] = GetHeardFromResourcesList();
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SubscriberViewModel model)
        {
            ViewData["HeardFromResourcesList"] = GetHeardFromResourcesList();

            if (ModelState.IsValid)
            {
                if (!this._subscriberService.IsExist(model.Email))
                {
                    Subscriber subscriber = new Subscriber()
                    {
                        Id = Guid.NewGuid(),
                        Email = model.Email,
                        HeardFrom = model.HeardFrom,
                        ReasonForSignup = model.ReasonForSignup
                    };
                    this._subscriberService.Create(subscriber);

                    return RedirectToAction("FinishSignUp", "Newsletter");
                }
                else
                {
                    ModelState.AddModelError("", Resources.Resources.EmailIsExist);
                    return View(model);
                }    
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult FinishSignUp()
        {
            return View();
        }

        public ActionResult GetAllSubscribers()
        {
            var subscribers = this._subscriberService.GetAll();
            List<SubscriberViewModel> subscriberList = new List<SubscriberViewModel>();
            foreach (var subscriber in subscribers)
            {
                subscriberList.Add(new SubscriberViewModel
                {
                    Id=subscriber.Id,
                    Email = subscriber.Email,
                    HeardFrom = subscriber.HeardFrom,
                    HeardFromDescription = subscriber.HeardFrom.GetDescription(),
                    ReasonForSignup = subscriber.ReasonForSignup
                });
            }

            return View(subscriberList);
        }
        private SelectList GetHeardFromResourcesList()
        {
            return new SelectList(Enum.GetValues(typeof(HeardFromResources)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.GetDescription(),
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text");
        }
    }
}