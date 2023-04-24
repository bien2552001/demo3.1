using System;

namespace BACKEND.Entities.DTO.DataDto.PZEM017
{
    public class PZEM017_Get_Dto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double U1 { get; set; }
        public double I1 { get; set; }
        public DateTimeOffset Date { get; set; }

        public string FormattedDate { get; set; }

    }
}
