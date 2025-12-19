using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kids_Converter.MVVM.Models
{
    public class Measurement
    {
        public enum MeasurementCategory
        {
            Information,
            Volume,
            Length,
            Mass,
            Temperature,
            Energy,
            Area,
            Speed,
            Duration
        }
    }
}

