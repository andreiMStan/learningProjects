﻿using IdentityTeddy2022.Models;
using IdentityTeddy2022.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTeddy2022.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		//This is the get method for the to get the first view with the form
		public async Task<IActionResult> Register(string? returnUrl = null)

		{
			RegisterViewModel registerViewModel = new RegisterViewModel();
			registerViewModel.ReturnUrl = returnUrl;
			return View(registerViewModel);
		}
		[HttpGet]
		public IActionResult Login(string? returnUrl = null)
		{
			LoginViewModel loginViewModel = new LoginViewModel();
			loginViewModel.ReturnUrl = returnUrl ?? Url.Content("~/");
			return View(loginViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				if (result.IsLockedOut)

				{
					return View("Lockout");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "invalid login attempt. ");
				}
				return View(loginViewModel);
			}
			return View(loginViewModel);
		}



		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
		{
			registerViewModel.ReturnUrl = returnUrl;
			returnUrl = returnUrl ?? Url.Content("~/");
			if (ModelState.IsValid)
			{
				var user = new AppUser { Email = registerViewModel.Email, UserName = registerViewModel.UserName };
				var result = await _userManager.CreateAsync(user, registerViewModel.Password);

				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return LocalRedirect(returnUrl);
				}
				ModelState.AddModelError("Password", "User could not be created.Password not unique enough");
			}
			return View(registerViewModel);

		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}


		//	[HttpGet]
		//	public IActionResult ForgotPassword()
		//	{
		//		return View();
		//	}

		//	[HttpPost]
		//	public IActionResult		ForgotPassword()
		//	{

		//	}
		//}

	}
}
