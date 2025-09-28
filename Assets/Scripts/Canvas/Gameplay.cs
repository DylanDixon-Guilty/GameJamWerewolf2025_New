using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI outputText;

    [SerializeField] private Location[] locations = new Location[5];

    private int locationIndex = 0;

    private int location;

    private void Reset()
    {
        // Pre-fill 5 entries with the required names to make setup easy
        locations = new Location[5];
        locations[0] = new Location("Bedroom");
        locations[1] = new Location("Neighborhood");
        locations[2] = new Location("Crosswalk");
        locations[3] = new Location("Park");
        locations[4] = new Location("Alley");
    }

    private void Awake()
    {
        if (locations == null || locations.Length != 5)
        {
            Debug.LogError("Please keep exactly 5 locations in order: Bedroom, Neighborhood, Crosswalk, Park, Alley.");
            return;
        }

        locationIndex = 0;
    }


    public void Smell()
    {
        Debug.Log("Smell Pressed");
        Describe(Sense.Smell);
    }

    public void Listen()
    {
        Debug.Log("Listen Pressed");
        Describe(Sense.Listen);
    }

    public void Touch()
    {
        Debug.Log("Touch Pressed");
        Describe(Sense.Touch);
    }

    public void Look()
    {
        Debug.Log("Look Pressed");
        Describe(Sense.Look);
    }

    public void Eat()
    {
        Debug.Log("Eat Pressed");
        Move();
    }

    public void Move()
    {
        Debug.Log("Move Pressed");
        if (locationIndex >= locations.Length - 1)
        {
            WriteLine("You’ve reached the Alley. No further paths ahead.");
            return;
        }

        locationIndex += 1;
        WriteLine("You move on looking for food.");
    }

    public void OnQuitPressed()
    {
        Debug.Log("Quit Pressed");
        Application.Quit();
    }

    public void OnOptionsPressed()
    {
        Debug.Log("Options Pressed");
        CanvasManager.Instance.ShowCanvasOptions();
    }

    private void Describe(Sense sense)
    {
        Debug.Log(sense + " Pressed");
        Food food = CurrentFood();
        if (food == null)
        {
            WriteLine("There’s no food here.");
            return;
        }

        string text = null;
        switch (sense)
        {
            case Sense.Smell:
                text = Fallback(food.smellDesc, "It has a faint, familiar aroma.");
                break;
            case Sense.Listen:
                text = Fallback(food.soundDesc, "It is quiet. Suspiciously quiet.");
                break;
            case Sense.Touch:
                text = Fallback(food.touchDesc, "The texture surprises you—neither pleasant nor awful.");
                break;
            case Sense.Look:
                text = Fallback(food.lookDesc, "You see it clearly now; very much… food-shaped.");
                break;
        }

        WriteLine(text);
    }

    private string Fallback(string value, string fallback)
    {
        if (string.IsNullOrWhiteSpace(value)) return fallback;
        return value;
    }

    private Location CurrentLocation()
    {
        return locations[locationIndex];
    }

    private Food CurrentFood()
    {
        Location loc = CurrentLocation();
        if (loc == null) return null;
        return loc.food;
    }

    private void WriteLine(string text)
    {
        if (outputText == null)
        {
            Debug.LogWarning("[Gameplay] " + text);
            return;
        }
        outputText.text = text;
    }
}

public enum Sense { Smell, Listen, Touch, Look }

[Serializable]
public class Food
{
    public string name = "Food";
    [TextArea] public string smellDesc;
    [TextArea] public string soundDesc;
    [TextArea] public string touchDesc;
    [TextArea] public string lookDesc;
}

[Serializable]
public class Location
{
    public string locationName;
    public Food food = new Food();

    public Location(string name)
    {
        locationName = name;
    }
}
