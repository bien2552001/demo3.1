using System;

namespace BACKEND.Entities.Model.Data_Mo.PZEM017
{
    public class PZEM017_Model
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double U1 { get; set; }
        public double I1 { get; set; }
        public DateTimeOffset Date { get; set; }

        public string FormattedDate { get; set; }
    }

}
