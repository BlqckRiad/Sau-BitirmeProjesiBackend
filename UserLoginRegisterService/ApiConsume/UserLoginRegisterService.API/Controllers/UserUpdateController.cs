using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using UserLoginRegisterService.BusinessLayer.Abstract;
using UserLoginRegisterService.DtoLayer.Dtos.Update;

namespace UserLoginRegisterService.API.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
	public class UserUpdateController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IRoleService _roleService;
        public UserUpdateController(IUserService userService , IRoleService roleService)
        {
            _userService = userService;
			_roleService = roleService;
        }
		[HttpPost]
		public ActionResult UserUpdate(UserUpdateDto model)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest("Model Uygun Değildir.");
			}
			var user = _userService.TGetByid(model.UserID);
			if(user == null)
			{
				return BadRequest("Kullanıcı Bulunamadı.");
			}
			user.UpdatedDate = DateTime.Now;
			user.UpdatedUserID = model.UpdatedUserID;
			user.Name = model.Name;
			user.SurName = model.SurName;
			user.UserName = model.UserName;
			user.UserDate = model.UserDate;
			user.UserSexsID = model.UserSexsID;
			_userService.TUpdate(user);
			return Ok(model);
		}
		[HttpPost]
		public IActionResult UserEmailUpdate(UserEmailUpdateDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Model Uygun Değildir.");
			}
			var user = _userService.TGetByid(model.UserID);
			if (user == null)
			{
				return BadRequest("Kullanıcı Bulunamadı.");
			}
			user.UserEmail = model.NewEmail;
			user.UpdatedDate = DateTime.Now;
			user.UpdatedUserID = model.UpdatedUserID;
			_userService.TUpdate(user);
			return Ok(model);
		}
		[HttpPost]
		public IActionResult UserTelNoUpdate(UserTelNoUpdatDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Model Uygun Değildir.");
			}
			var user = _userService.TGetByid(model.UserID);
			if (user == null)
			{
				return BadRequest("Kullanıcı Bulunamadı.");
			}
			user.UserTelNo = model.NewTelNo;
			user.UpdatedDate = DateTime.Now;
			user.UpdatedUserID = model.UpdatedUserID;
			_userService.TUpdate(user);

			return Ok(model);
		}
		[HttpPost]
		public IActionResult UserImageUpdate(UserImageUpdateDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Model Uygun Değildir.");
			}
			var user = _userService.TGetByid(model.UserID);
			if (user == null)
			{
				return BadRequest("Kullanıcı Bulunamadı.");
			}
			user.UserImageID = model.NewImageID;
			user.UserImageUrl = model.NewImageUrl;
			user.UpdatedDate = DateTime.Now;
			user.UpdatedUserID = model.UpdatedUserID;
			_userService.TUpdate(user);
			return Ok(model);
		}
		[HttpPost]
		public IActionResult UserPasswordUpdate(UserPasswordUpdateDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Model Uygun Değildir.");
			}
			var user = _userService.TGetByid(model.UserID);
			if (user == null)
			{
				return BadRequest("Kullanıcı Bulunamadı.");
			}
			var oldpas = model.Password;
			var newpass = model.Password;

			using (SHA256 sha = SHA256.Create())
			{
				string hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(oldpas)));
				if (user.Password != hashedPassword)
				{
					return BadRequest("Şifre hatalı.");
				}
				else
				{
					string hashednewpass = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(newpass)));
					user.Password = hashednewpass;
					user.UpdatedDate= DateTime.Now;
					user.UpdatedUserID = model.UpdatedUserID;
					_userService.TUpdate(user);
					return Ok();
				}
			}
		}
		[HttpPost]
		public IActionResult ChangeUserRoleID (ChangeUserRoleDto model)
		{
			var user = _userService.TGetByid (model.UserID);
			if (user == null)
			{
				return BadRequest("Kullanıcı Bulunamadı.");
			}
			user.UserRoleID = model.RoleID;
			user.UpdatedDate = DateTime.Now;
			user.UpdatedUserID = model.UpdatedUserID;
			_userService.TUpdate(user);
			return Ok();

        }
	}
}
