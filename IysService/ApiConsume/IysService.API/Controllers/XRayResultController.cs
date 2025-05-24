using AutoMapper;
using IysService.BusinessLayer.Abstract;
using IysService.DtoLayer.Dtos;
using IysService.DtoLayer.MappingDtos;
using IysService.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IysService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class XRayResultController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IXRayResultService _xrayResultService;
        public XRayResultController(IMapper mapper , IXRayResultService xRayResultService)
        {
            _mapper = mapper;
            _xrayResultService = xRayResultService;
        }
        [HttpGet]
        public IActionResult GetAllXRayResults()
        {
            var xrayresults = _xrayResultService.TGetList().Where(x => x.IsDeleted == false);
            var xrayresultmappeds = _mapper.Map<List<XRayResultListDto>>(xrayresults);

            return Ok(xrayresultmappeds);
        }
        [HttpGet]
        public IActionResult GetXRayResultWithId (int id)
        {
            var xrayresult = _xrayResultService.TGetByid(id);
            var xrayresultmapped = _mapper.Map<XRayResultListDto>(xrayresult);

            return Ok(xrayresultmapped);
        }
        [HttpGet]
        public IActionResult GetXRayResultsWithUserID (int userId)
        {
            var xrayresults = _xrayResultService.TGetList().Where(x => x.IsDeleted == false && x.UserID == userId);
            var xrayresultmappeds = _mapper.Map<List<XRayResultListDto>>(xrayresults);

            return Ok(xrayresultmappeds);
        }
        [HttpGet]
        public IActionResult GetXRayResultsWithDoctorID (int doctorID)
        {
            var xrayresults = _xrayResultService.TGetList().Where(x => x.IsDeleted == false && x.UserID == doctorID);
            var xrayresultmappeds = _mapper.Map<List<XRayResultListDto>>(xrayresults);

            return Ok(xrayresultmappeds);
        }
        [HttpPost]
        public IActionResult AddXRayResultWithOutFinaly (AddXRayResultWithOutFinalyDto model)
        {
            var newxrayresult = new XRayResult
            {
                UserID = model.UserID,
                DoctorID = model.DoctorID,
                XRayNormalImageID = model.XRayNormalImageID,
                XRayNormalImageUrl = model.XRayNormalImageUrl,
            };
            _xrayResultService.TAdd(newxrayresult);
            return Ok(newxrayresult);
        }

        [HttpPost]
        public IActionResult UpdateXRayResultWithFinaly (UpdateXRayResultWithFinalyDto model)
        {
            var xrayresult = _xrayResultService.TGetByid(model.XRayResultID);
            if(xrayresult == null)
            {
                return NotFound("XRayResult Değeri Bulunamadı.");
            }
            xrayresult.XRayTitle = model.XRayTitle;
            xrayresult.XRayDescription = model.XRayDescription;
            xrayresult.XRayImageIsFinished = model.XRayImageIsFinished;
            xrayresult.XRayFinishedImageID = model.XRayFinishedImageID;
            xrayresult.XRayFinishedImageUrl = model.XRayFinishedImageUrl;
            _xrayResultService.TUpdate(xrayresult);
            return Ok(xrayresult);
        }
    }
}
