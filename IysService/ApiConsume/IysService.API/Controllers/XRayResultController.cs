using AutoMapper;
using IysService.BusinessLayer.Abstract;
using IysService.DtoLayer.Dtos;
using IysService.DtoLayer.MappingDtos;
using IysService.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> AddXRayResultWithOutFinaly(AddXRayResultWithOutFinalyDto model)
        {
            string prediction = string.Empty;
            string confidence = string.Empty;

            using (var httpClient = new HttpClient())
            {
                var requestBody = new
                {
                    url = model.XRayNormalImageUrl
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://brainaimodel-production.up.railway.app/predict", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<XRayPredictionResponse>(responseContent);

                    prediction = result?.Prediction;
                    confidence = result?.Confidence;
                }
                else
                {
                    return BadRequest("Model tahmin servisi başarısız oldu.");
                }
            }

            var newxrayresult = new XRayResult
            {
                UserID = model.UserID,
                DoctorID = model.DoctorID,
                XRayNormalImageID = model.XRayNormalImageID,
                XRayNormalImageUrl = model.XRayNormalImageUrl,
                // Örnek ekleme (veritabanında bu alanlar varsa)
                XRayTitle = prediction,
                XRayDescription = confidence,
                XRayImageIsFinished = true,
                CreatedDate = DateTime.Now,
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
            _xrayResultService.TUpdate(xrayresult);
            return Ok(xrayresult);
        }

        [HttpPost]
        public IActionResult LastDisResult(LastDisResult model)
        {
            var newxrayresult = new XRayResult
            {
                UserID = model.UserID,
                DoctorID = model.DoctorID,
                XRayNormalImageID = model.XRayNormalImageID,
                XRayNormalImageUrl = model.XRayNormalImageUrl,
                XRayTitle = model.XRayTitle,
                XRayDescription = model.XRayDescription,
                XRayImageIsFinished = true,
                CreatedDate = DateTime.Now,
            };
            _xrayResultService.TAdd(newxrayresult);
            return Ok(newxrayresult);
        }
    }
}
