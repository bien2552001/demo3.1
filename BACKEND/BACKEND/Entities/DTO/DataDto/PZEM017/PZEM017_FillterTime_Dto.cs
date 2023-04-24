using System;

namespace BACKEND.Entities.DTO.DataDto.PZEM017
{
    public class PZEM017_FillterTime_Dto
    {
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }

        public string FormattedStart
        {
            get { return Start?.ToString("dd/MM/yyyy"); }
        }

        public string FormattedEnd
        {
            get { return End?.ToString("dd/MM/yyyy"); }
        }
    }
}
