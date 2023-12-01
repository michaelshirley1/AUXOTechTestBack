using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechTestMikeS.Classes;
using Formatting = Newtonsoft.Json.Formatting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

Dictionary<int, Part> allParts = new Dictionary<int, Part>
{
    { 1, new Part(1, new Dictionary<string, string> { { "description", "Wire" }, { "price", "5.99" }, { "quantity", "5" }}) },
    { 2, new Part(2, new Dictionary<string, string> { { "description", "Break Fluid" }, { "price", "4.90" }, { "quantity", "20" } }) },
    { 3, new Part(3, new Dictionary<string, string> { { "description", "Engine Oil" }, { "price", "15.00" }, { "quantity", "12" } }) }
};

Dictionary<int, Order> allOrders = new Dictionary<int, Order> {
    { 1, new Order(1, new List<Part>{ allParts[1], allParts[2] } )},
    { 2, new Order(2, new List<Part>{ allParts[3] } )},
};


app.MapPost("/parts", (string? json) =>
{
    var deserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    if (deserialized != null)
    {
        int identifier = allParts.Count + 1;
        allParts.Add(identifier, new Part(identifier, deserialized));
    }
});

app.MapGet("/parts", () =>
{
    return JsonConvert.SerializeObject(allParts, Formatting.Indented);
});

app.MapPost("/orders", (string json) =>
{
    var deserialized = JsonConvert.DeserializeObject<List<Part>>(json);
    if (deserialized != null)
    {
        int identifier = allOrders.Count + 1;
        Order thisOrder = new Order(identifier, deserialized);
        allOrders.Add(identifier, thisOrder);
    }
});

app.MapGet("/orders", () =>
{
    return JsonConvert.SerializeObject(allOrders, Formatting.Indented);
});

app.Run();