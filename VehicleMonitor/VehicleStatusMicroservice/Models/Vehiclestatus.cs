using System;
using System.Collections.Generic;

namespace VehicleStatusMicroservice.Models;

public partial class Vehiclestatus
{
    public int StatusId { get; set; }

    public int? VehicleId { get; set; }

    public string? Status { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
