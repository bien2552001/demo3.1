using System;

namespace BACKEND.Entities.DTO.DataDto.PZEM017
{
    public class Test_Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //Điện áp 
        public float U1 { get; set; }
        //Dòng điện 
        public float I1 { get; set; }
        //public string Gio { get; set; }
        //public string Ngay { get; set; }
        //public string Thang { get; set; }
        //public string Nam { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
