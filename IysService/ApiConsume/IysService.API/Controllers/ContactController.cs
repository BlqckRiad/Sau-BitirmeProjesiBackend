using AutoMapper;
using IysService.BusinessLayer.Abstract;
using IysService.DtoLayer.Dtos;
using IysService.DtoLayer.GeneralDtos;
using IysService.DtoLayer.MappingDtos;
using IysService.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IysService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService , IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contact = _contactService.TGetList().Where(x => x.IsDeleted == false);
            var contactMappeds = _mapper.Map<List<ContactListMapDto>>(contact);

            return Ok(contactMappeds);
        }
        [HttpGet]
        public IActionResult GetContactWithID(int id)
        {
            var contact = _contactService.TGetByid(id);
            var contactMapped = _mapper.Map<ContactListMapDto>(contact);
            return Ok(contactMapped);
        }
        [HttpPost]
        public IActionResult AddContact (AddContactDto model)
        {
            var newcontact = new Contact
            {
                ContactUserEmail = model.ContactUserEmail,
                ContactUserName = model.ContactUserName,
                Subject = model.Subject,
                Message = model.Message,
                CreatedDate = DateTime.Now,
                CreatedUserID = 0,
            };
            _contactService.TAdd(newcontact);
            return Ok();
        }
        [HttpPost]
        public IActionResult CheckContact (JustIDDto model)
        {
            var contact = _contactService.TGetByid(model.ItemID);
            if(contact == null)
            {
                return NotFound("Contact mesajı bulunamadı.");
            }
            contact.IsChecked = true;
            _contactService.TUpdate(contact);
            return Ok();
        }
        [HttpPost]
        public IActionResult UnCheckContact(JustIDDto model)
        {
            var contact = _contactService.TGetByid(model.ItemID);
            if (contact == null)
            {
                return NotFound("Contact mesajı bulunamadı.");
            }
            contact.IsChecked = false;
            _contactService.TUpdate(contact);
            return Ok();
        }
    }
}
