using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using Microsoft.Extensions.Options;
using PlateTimeApp.Models;
using PlateTimeApp.Repositories;

namespace PlateTimeApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly PlateTimeContext _context;
        private readonly IServiceProvider _serviceProvider;
        IConfiguration _configuration;
        private EmailRepo emailRepo;
        private EmailSettings _emailSettings;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            PlateTimeContext context,
            IServiceProvider serviceProvider,
            IOptions<EmailSettings> emailSettings,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _serviceProvider = serviceProvider;
            _configuration = configuration;

            _emailSettings = emailSettings.Value;
            emailRepo = new EmailRepo(_emailSettings);

            //emailRepo.SendMail("gregory.maxedon@gmail.com", "hello from platetime", @"<p>Thanks for signing up.<p>");
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            //[Required]

            //[Display(Name = "Username")]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]

            //public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [RegularExpression(@"Manager|Member")]
            public string Usertype { get; set; }
        }

        //public void OnGet(string returnUrl = null)
        //{
        //    ViewData["SiteKey"] = _configuration["Recaptcha:SiteKey"];
        //    ReturnUrl = returnUrl;
        //}

        //[ValidateRecaptcha]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");



                    // creates a new restraunt or restraunt goer associated with the new user and adds role
                    UserRoleAccountRepo userRoleRepo = new UserRoleAccountRepo(_context, _serviceProvider);
                    var usertype = Input.Usertype;
                    var userid = user.Id;
                    var email = user.Email;
                    if (usertype == "Member")
                    {
                        await userRoleRepo.AddUserRole(email, "Member");

                        RestaurantGoer restaurantgoer = new RestaurantGoer()
                        {
                            UserId  = userid,
                            User    = _context.AspNetUsers.Where(u => u.Id == userid)
                                        .FirstOrDefault()
                        };
                        await _context.AddAsync(restaurantgoer);
                        await _context.SaveChangesAsync();
                    }
                    if (usertype == "Manager")
                    {
                        await userRoleRepo.AddUserRole(email, "Manager");

                        Restaurant restaurant = new Restaurant()
                        {
                            UserId = userid,
                            User = _context.AspNetUsers.Where(u => u.Id == userid)
                                        .FirstOrDefault()
                        };
                        await _context.AddAsync(restaurant);
                        await _context.SaveChangesAsync();
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // Reset the site key if there is an error.
           // ViewData["SiteKey"] = _configuration["Recaptcha:SiteKey"];

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
