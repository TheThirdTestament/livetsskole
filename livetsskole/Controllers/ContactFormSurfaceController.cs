using livetsskole.ViewModels;
using reCAPTCHA.MVC;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;


namespace livetsskole.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("contactForm", new ContactMessage());
        }

        [HttpPost]
        [CaptchaValidator]
        public ActionResult HandleFormSubmit(ContactMessage model, bool captchaValid)
        {

            //if (!captchaValid)
            //{
            //    ModelState.AddModelError("_FORM", "You did not type the verification word correctly. Please try again.");
            //}
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }

            MailMessage message = new MailMessage();
            message.To.Add("mail@dettredietestamente.info");
            //message.To.Add("mail@dettredietestamente.info");
            //message.CC.Add("jan@langekaer.dk");
            message.To.Add("jesarbov@gmail.com");
            message.CC.Add("jesarbov@gmail.com");
            message.Subject = "Mail fra livetsskole.info: " + model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;

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

            IContent msg = Services.ContentService.Create(model.Subject, CurrentPage.Id, "message");
            msg.SetValue("messageName", model.Name);
            msg.SetValue("email", model.Email);
            msg.SetValue("subject", model.Subject);
            msg.SetValue("messageText", model.Message);

            Services.ContentService.Save(msg);

            return RedirectToCurrentUmbracoPage();
        }
    }
}