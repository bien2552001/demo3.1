using BACKEND.Entities.DTO.DataDto.DTSU666;
using BACKEND.Entities.Model.Data_Mo.DTSU666;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BACKEND.Entities.Model.Data_Mo.PZEM017;
using BACKEND.Entities.DTO.DataDto.PZEM017;
using BACKEND.Controllers.Data_Co;

namespace BACKEND.Interface.IData.IPZEM017
{
    public interface IPZEM017_Repository
    {
   
        Task<IEnumerable<PZEM017_Model>> GetAllAsync(PZEM017_DataShapping_Dto repuestShapping, PZEM017_FillterTime_Dto fillter);

        Task CreateAsync(PZEM017_Model data); 
      

    }
}
