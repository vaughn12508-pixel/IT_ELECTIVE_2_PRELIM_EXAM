using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

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

        // Assert meals array has more than 0 items
        if (meals.ValueKind == JsonValueKind.Null ||
            meals.GetArrayLength() <= 0)
        {
            throw new Exception("No meals found.");
        }

        // Loop through meals and print names
        foreach (JsonElement meal in meals.EnumerateArray())
        {
            string mealName = meal.GetProperty("strMeal").GetString() ?? "";

            Console.WriteLine(mealName);
        }
    }
}