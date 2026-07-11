using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52771";

        // Send GET request
        var response = await client.GetAsync(url);

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK but got {response.StatusCode}");
        }

        // Read response content
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using JsonDocument document = JsonDocument.Parse(body);

        // Get meals array
        JsonElement meals = document.RootElement.GetProperty("meals");

        // Make sure meal exists
        if (meals.ValueKind == JsonValueKind.Null || meals.GetArrayLength() == 0)
        {
            throw new Exception("No meal found.");
        }

        // Access first meal22
        JsonElement meal = meals[0];

        // Read strMeal
        string mealName = meal.GetProperty("strMeal").GetString() ?? "";

        // Assert meal name
        if (mealName != "Spicy Arrabiata Penne")
        {
            throw new Exception(
                $"Expected 'Spicy Arrabiata Penne' but got '{mealName}'"
            );
        }
    }
}