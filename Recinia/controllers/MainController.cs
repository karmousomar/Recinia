using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recinia.Entities;
using Recinia.Models;
using Recinia.Services;
using Recinia.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recinia.controllers
{
    public class MainController : Controller
    {
        //Identity login register controller
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSend emailSend;
        private readonly ISmsSend smsSend;
        public MainController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager,IEmailSend _emailSend,
            ISmsSend _smsSend)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            emailSend = _emailSend;
            smsSend = _smsSend;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoggingVM model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index","LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Invalid information mother fucker");
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistreView model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.UserName
                };
                var identityResults = await userManager.CreateAsync(identityUser, model.Password);
                if (identityResults.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var callbackUrl = Url.Action("ConfirmEmail","Main",new { userId=identityUser.Id,code=code},protocol:HttpContext.Request.Scheme);
                    await emailSend.SendEmailAsync(model.UserName, "Confirm Acount",
                        $"please Confirm Your Acount By"
                        + $"Clicking this link:<a href='{callbackUrl}'>Link</a>");
                    await signInManager.SignInAsync(identityUser, isPersistent: false);
                    return View(model);
                    //return RedirectToAction("Index", "LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in Creating the User");
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>ConfirmEmail(string userId,string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await userManager.FindByIdAsync(userId);
            if(user==null)
            {
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user,code);
            return View("ConfirmEmail");
        }
        public IActionResult Reset()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(ResetPassword model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user==null)
                {

                    return RedirectToAction("Index", "Main");
                }
                //var code = "token";
                var results = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (!results.Succeeded)
                {
                    return View(model);
                }
                else
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            return View(model);
        }
        public IActionResult Oublier()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Oublier(MotDePassOublier model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                var confirmed = await userManager.IsEmailConfirmedAsync(user);
                if(user==null||!(confirmed))
                {
                    return View("ForgotPasswordConfirmation");
                }
                //Send Email Confirmation
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("Reset", "Main", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await emailSend.SendEmailAsync(model.Email, "Reset PassWord",
                    $"please Reset Your Password By"
                    + $"Clicking this link:<a href='{callbackUrl}'>Link</a>");
                
            }
            return View(model);
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Main");
        }
       public async Task<IActionResult> TestEMail()
        {
            await emailSend.SendEmailAsync("atlas.karmous@gmail.fr", "Done! Check Your E-mail To Confirm", "My first Send Grid Email");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SmsTest()
        {
            await smsSend.SendSmsAsync("21650905004", "these is a test message from omar");
            return RedirectToAction("Index", "Main");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider,string returnUrl=null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Main", new
            {
                returnUrl = returnUrl
            });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl=null,string remoteError=null)
        {
            if (remoteError != null)
            {
                return View(nameof(ExternalLoginFailure));
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info==null)
            {
                return RedirectToActionPermanent(nameof(ExternalLoginFailure));
            }
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation",new ELCVM { Email = email });
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ELCVM model,string returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                var info = await signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var AlreadyRegistered = await userManager.FindByEmailAsync(model.Email);
                var result = await userManager.CreateAsync(user);
                if(result.Succeeded||AlreadyRegistered.UserName !=null)
                {
                    result = await userManager.AddLoginAsync(user, info);
                    if (result.Succeeded || AlreadyRegistered.UserName != null)
                    {
                        await signInManager.SignInAsync(user, isPersistent:false);
                        RedirectToAction("Index,LoggedIn");
                    }
                }
                
            }
            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }
        public IActionResult ExternalLoginFailure()
        {
            return View();
        }
    }

}
