﻿namespace FoodDelivery.WebAPI.Controllers.Entities.Deliveries;

public class CreateDeliveryRequest
{
    public string Title { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
}
