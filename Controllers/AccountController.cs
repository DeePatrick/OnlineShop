using OnlineShop.Abstract;
using OnlineShop.Models.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthentication authentication;
        public AccountController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authentication.Authenticate(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));

                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                }
            }

            return View();


        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }

    }
}

