

namespace SmyzeTask.Model
{
    public class CarDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Offer { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Brand)
                && !string.IsNullOrEmpty(Offer)
                && !string.IsNullOrEmpty(Offer);
        }
    }
}
