using Microsoft.ML.Data;

namespace HousePricePrediction_Manual
{
    public class ModelOutput
    {
        [ColumnName(@"Index")]
        public float Index { get; set; }

        [ColumnName(@"Area")]
        public float Area { get; set; }

        [ColumnName(@"Age")]
        public float Age { get; set; }

        [ColumnName(@"Rooms")]
        public float Rooms { get; set; }

        [ColumnName(@"District")]
        public float District { get; set; }

        [ColumnName(@"PricePerMeter")]
        public float PricePerMeter { get; set; }

        [ColumnName(@"Price")]
        public float Price { get; set; }

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"Score")]
        public float Score { get; set; }
    }
}
