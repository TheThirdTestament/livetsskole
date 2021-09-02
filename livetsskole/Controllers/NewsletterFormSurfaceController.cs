using livetsskole.ViewModels;
using reCAPTCHA.MVC;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;


namespace DttInfo.Controllers
{
    public class NewsletterFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("newsletterForm", new NewsletterRegistration());
        }

        [HttpPost]
        [CaptchaValidator]
        public ActionResult HandleFormSubmit(NewsletterRegistration model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }

            MailMessage message = new MailMessage();
            //message.To.Add("mail@dettredietestamente.info");
            message.CC.Add("jan@langekaer.dk");
            //message.To.Add("jesarbov@gmail.com");
            message.CC.Add("jesarbov@gmail.com");
            message.Subject = "Mail fra livetsskole.info: Tilmelding til nyhedsbrev";
            message.From = new MailAddress(model.Email, model.Firstname + " " + model.Lastname);
            message.Body = model.Firstname + " " + model.Lastname + ": " + model.Email;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("jesarbov@gmail.com", "yapxnkiyjdmgskcj");
                smtp.EnableSsl = true;

                // send mail
                smtp.Send(message);
                TempData["success"] = true;
            }

            IContent msg = Services.ContentService. Create(model.Firstname + " " + model.Lastname, CurrentPage.Id, "newsletterRegistration");
            msg.SetValue("firstname", model.Firstname);
            msg.SetValue("lastname", model.Lastname);
            msg.SetValue("email", model.Email);
            
            Services.ContentService.Save(msg);

            return RedirectToCurrentUmbracoPage();
        }
    }
}