using System;
using System.Collections.Generic;

namespace VehicleStatusMicroservice.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int? CustomerId { get; set; }

    public string? Vin { get; set; }

    public string? RegNumber { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Vehiclestatus> Vehiclestatuses { get; } = new List<Vehiclestatus>();
}
