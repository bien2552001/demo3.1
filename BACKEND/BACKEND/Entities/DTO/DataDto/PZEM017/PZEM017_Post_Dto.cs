using System;

namespace BACKEND.Entities.DTO.DataDto.PZEM017
{
    public class PZEM017_Post_Dto
    {
        public string Name = "Đồng hồ Pzem017";
        //Điện áp 
        public double U1 { get; set; }
        //Dòng điện 
        public double I1 { get; set; }

        public DateTimeOffset Date = DateTimeOffset.Now;

        public string FormattedDate
        {
            get { return Date.ToString("dd/MM/yyyy"); }
        }
    }
}
