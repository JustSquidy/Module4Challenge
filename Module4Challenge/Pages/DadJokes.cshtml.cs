using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module4Challenge.Pages;

public class DadJokesModel : PageModel
{
    // This array stores all the dad jokes I found 
    public string[] AllJokes { get; set; } =
    {
        "Why don’t skeletons fight each other? They don’t have the guts.",
        "I only know 25 letters of the alphabet. I don’t know y.",
        "Why did the scarecrow win an award? Because he was outstanding in his field.",
        "I’m reading a book about anti-gravity. It’s impossible to put down.",
        "Did you hear about the restaurant on the moon? Great food, no atmosphere.",
        "Why don’t eggs tell jokes? They’d crack each other up.",
        "I used to play piano by ear, now I use my hands.",
        "Why did the math book look sad? It had too many problems.",
        "I told my wife she was drawing her eyebrows too high. She looked surprised.",
        "Why can’t your nose be 12 inches long? Because then it would be a foot.",
        "I would tell you a construction joke, but I’m still working on it.",
        "Why did the coffee file a police report? It got mugged."
    };

    public string[] CurrentJokes { get; set; } = new string[0];

    // How many jokes to show at once (at least 2)
    public int NumberOfJokesToShow { get; set; } = 2;

    // Random generator for randomization of jokes
    static Random rnd = new Random();

    // Stores the last shown joke indexes (avoid repeating twice in a row)
    static int[] lastIndexes = new int[0];

    public void OnGet()
    {
        PickRandomJokes();
    }

    public void OnPost()
    {
        PickRandomJokes();
    }

    public void PickRandomJokes() // This function picks random jokes from the AllJokes array and stores them in the CurrentJokes array, while ensuring that the same joke is not shown twice in a row
    {
        CurrentJokes = new string[NumberOfJokesToShow];
        int[] newIndexes = new int[NumberOfJokesToShow];

        for (int i = 0; i < NumberOfJokesToShow; i++)
        {
            int randomIndex = rnd.Next(0, AllJokes.Length);

            while (ContainsValue(newIndexes, randomIndex) || ContainsValue(lastIndexes, randomIndex))
            {
                randomIndex = rnd.Next(0, AllJokes.Length);
            }

            newIndexes[i] = randomIndex;
            CurrentJokes[i] = AllJokes[randomIndex];
        }

        lastIndexes = newIndexes;
    }

    public bool ContainsValue(int[] arr, int value) // This function checks if a given value is present in an array
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value)
            {
                return true;
            }
        }
        return false;
    }
}