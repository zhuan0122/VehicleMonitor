namespace VehicleStatusMicroService.ViewModels
{
    public class VehicleStatusViewModel
    {
        public int VehicleId { get; set; }
        public string? RegNumber { get; set; }
        public int StatusId { get; set; }
        public string? Status { get; set; }
    }
}