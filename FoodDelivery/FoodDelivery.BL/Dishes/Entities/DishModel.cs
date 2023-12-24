﻿namespace FoodDelivery.BL.Dishes.Entities;

public class DishModel
{
    public Guid Id { get; set; }
    public string DishName { get; set; }
    public string Description { get; set; }
    public int NumberOfGrams { get; set; }
    public string NutritionalValue { get; set; }
    public int Price { get; set; }
}
