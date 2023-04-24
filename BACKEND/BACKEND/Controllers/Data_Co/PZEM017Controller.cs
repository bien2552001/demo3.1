using AutoMapper;
using BACKEND.Extensions.Service.ActionFilters;
using BACKEND.Interface.IService.ILoggerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BACKEND.Interface.IData.IPZEM017;
using BACKEND.Entities.DTO.DataDto.PZEM017;
using BACKEND.Entities.Model.Data_Mo.PZEM017;
using BACKEND.Interface.IData.IDTSU666.Interface_Shapping_DTSU666;

namespace BACKEND.Controllers.Data_Co
{
    [Route("pzem017")]
    [ApiController]
    public class PZEM017Controller : ControllerBase
    {
        private readonly IPZEM017_Repository _repo;
        private readonly IDataShaper<PZEM017_Get_Dto> _dataShaper;
        private readonly ILoggerService _logger;
        private readonly IMapper _map;
        public PZEM017Controller(IPZEM017_Repository repo, ILoggerService logger, IMapper map, IDataShaper<PZEM017_Get_Dto> dataShaper)
        {
            _repo = repo;
            _logger = logger;
            _map = map;
            _dataShaper = dataShaper;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllAsync([FromQuery] PZEM017_DataShapping_Dto repuestShapping, [FromQuery] PZEM017_FillterTime_Dto fillterTime)
        {

            var pzemFromDb = await _repo.GetAllAsync(repuestShapping, fillterTime);

            var pzemDto = _map.Map<IEnumerable<PZEM017_Get_Dto>>(pzemFromDb);

            return Ok(_dataShaper.ShapeData(pzemDto, repuestShapping.Fields));
        }



        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter), Order = 3)]
        public async Task<ActionResult> CreateAsync([FromBody] PZEM017_Post_Dto dataDto)
        {
            var post = _map.Map<PZEM017_Model>(dataDto);

            await _repo.CreateAsync(post);

            var itemToReturn = _map.Map<PZEM017_Get_Dto>(post);

            _logger.LogInfo("========>>>>>>> POST successful");

            return CreatedAtAction(nameof(GetAllAsync), new { name = itemToReturn.Name }, itemToReturn);
        }

    }
}




//-------------------------------------------------------------------------------------

//[HttpGet("/hour")]
//public async Task<IActionResult> GetSensorDataByDay([FromQuery] DateTime date)
//{
//    var users = await _repo.GetSensorDataByDay(date);

//   var  pzemDto = _map.Map<IEnumerable<Test_Dto>>(users);

//    return Ok(pzemDto);
//}

//[HttpPost("/hour")]
//[ServiceFilter(typeof(ValidationFilter), Order = 3)]
//public async Task<ActionResult> Create1Async([FromBody]Test_Post_Dto dataDto)
//{
//    var post = _map.Map<PZEM017_Model>(dataDto);

//    await _repo.Create1Async(post);

//    var itemToReturn = _map.Map<Test_Dto>(post);

//    _logger.LogInfo("========>>>>>>> POST successful");

//    return CreatedAtAction(nameof(GetSensorDataByDay), new { id = itemToReturn.Id }, itemToReturn);
//}

//----------------------------------------------------------------------------------------------