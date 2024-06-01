﻿using BrainWave.DtoLayer.DataTransferObjects.AppUserDtos;
using BrainWave.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BrainWave.PresentationLayer.Controllers
{
	//[Authorize]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserInfoDtos appUserInfoDtos = new AppUserInfoDtos();
			appUserInfoDtos.Name = values.Name;
			appUserInfoDtos.Surname = values.Surname;
			appUserInfoDtos.About = values.About;
			appUserInfoDtos.Experience = values.Experience;
			appUserInfoDtos.Education = values.Education;
			appUserInfoDtos.Skills = values.Skills;
			appUserInfoDtos.Interests = values.Interests;
			return View(appUserInfoDtos);
		}
    }
}
