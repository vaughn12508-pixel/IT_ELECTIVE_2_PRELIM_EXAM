using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

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

        // Check meals field
        if (!document.RootElement.TryGetProperty("meals", out JsonElement meals))
        {
            throw new Exception("Response does not contain a meals field.");
        }

        // Assert meals is null
        if (meals.ValueKind != JsonValueKind.Null)
        {
            throw new Exception("Expected meals to be null, but a meal was returned.");
        }
    }
}