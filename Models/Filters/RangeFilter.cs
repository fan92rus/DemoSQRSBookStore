namespace App.Models.Filters
{
    public class RangeFilter : IFilter<float>
    {
        public float Min { get; set; }
        public float Max { get; set; }

        public bool Check(float value) => value >= Min && value <= Max;
    }
}