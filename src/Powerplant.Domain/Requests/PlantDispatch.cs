namespace Powerplant.Domain.Requests
{
    public class PlantDispatch
    {
        public PowerPlant Plant { get; set; }
        public decimal MarginalCost { get; set; }
        public decimal PowerProduced { get; set; }
    }
}
