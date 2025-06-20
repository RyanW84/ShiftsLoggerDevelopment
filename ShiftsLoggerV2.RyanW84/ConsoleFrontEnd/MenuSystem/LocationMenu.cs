﻿using ConsoleFrontEnd.Controller;
using Spectre.Console;

namespace ConsoleFrontEnd.MenuSystem;

public class LocationMenu()
{
    public static async Task DisplayLocationMenu()
    {
        LocationController locationController = new();

        AnsiConsole.Clear();
        while (true)
        {
            AnsiConsole.Write(
                new Rule("[bold yellow]Location Menu[/]").RuleStyle("yellow").Centered()
            );

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Select an option:[/]")
                    .AddChoices(
                        "Create Location",
                        "View Locations",
                        "View Location by ID",
                        "Update Location",
                        "Delete Location",
                        "Back to Main Menu"
                    )
            );

            switch (choice)
            {
                case "Create Location":
                    await locationController.CreateLocation();
                    break;
                case "View Locations":
                    await locationController.GetAllLocations();
                    break;
                case "View Location by ID":
                    await locationController.GetLocationById();
                    break;
                case "Update Location":
                    await locationController.UpdateLocation();
                    break;
                case "Delete Location":
                    await locationController.DeleteLocation();
                    AnsiConsole.MarkupLine(
                        "[red]Delete Location functionality is not implemented yet.[/]"
                    );
                    break;
                case "Back to Main Menu":
                    await MainMenu.DisplayMainMenu();
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid choice, please try again.[/]");
                    break;
            }
        }
    }
}
