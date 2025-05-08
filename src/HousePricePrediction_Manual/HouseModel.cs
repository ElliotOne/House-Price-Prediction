using Microsoft.ML.Data;

namespace HousePricePrediction_Manual
{
    public class HouseModel
    {
        [LoadColumn(0)]
        public float Index { get; set; }

        [LoadColumn(1)]
        public float Area { get; set; }

        [LoadColumn(2)]
        public float Age { get; set; }

        [LoadColumn(3)]
        public float Rooms { get; set; }

        [LoadColumn(4)]
        public float District { get; set; }

        [LoadColumn(5)]
        public float PricePerMeter { get; set; }

        [LoadColumn(6)]
        public float Price { get; set; }
    }
}
