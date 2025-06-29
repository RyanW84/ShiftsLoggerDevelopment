﻿namespace ConsoleFrontEnd.Models.FilterOptions;

public class LocationFilterOptions
{
    // This class defines the filter options for retrieving locations, allowing filtering by location ID and name.
    public int? LocationId { get; set; } = 0; // Optional filter by location ID
    public string? Name { get; set; } // Optional filter by location name
    public string? Description { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty; // Optional filter by location address
    public string? Town { get; set; } = string.Empty; // Optional filter by town or city
    public string? StateOrCounty { get; set; } = string.Empty; // Optional filter by state or county
    public string? ZipOrPostCode { get; set; } = string.Empty; // Optional filter by zip or post code
    public string? Country { get; set; } = string.Empty; // Optional filter by country
    public string? Search { get; set; } = string.Empty; // Optional search text for filtering locations
    public string? SortBy { get; set; } = "Name"; // Default sorting by name
    public string ? SortOrder { get; set; } = "asc"; // Default sorting order is ascending
}
