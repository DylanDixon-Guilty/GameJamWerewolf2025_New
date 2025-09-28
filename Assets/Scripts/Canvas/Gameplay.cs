using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class Gameplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private Location[] locations = new Location[5];
    [SerializeField] private SpriteRenderer backgroundRenderer;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private HungerBarManager hungerBarManager;
    private int locationIndex = 0;

    private void Awake()
    {
        if (hungerBarManager == null)
            hungerBarManager = UnityEngine.Object.FindFirstObjectByType<HungerBarManager>();

        if (hungerBarManager == null)
        {
            Debug.LogError("Gameplay: No HungerBarManager found in scene.");
            enabled = false;
            return;
        }

        if (locations == null || locations.Length != 5)
        {
            Debug.LogError("Please keep exactly 5 locations in order: Bedroom, Neighborhood, Crosswalk, Park, Alley.");
            return;
        }

        locationIndex = 0;
        UpdateBackground();
    }

    private void SpendTime(float amount)
    {
        float t = Mathf.Clamp(hungerBarManager.timeBar.value - amount, 0f, hungerBarManager.timeBar.maxValue);
        hungerBarManager.SetTime(t);
    }

    private void ChangeFood(float amount)
    {
        float f = Mathf.Clamp(hungerBarManager.foodBar.value + amount, 0f, hungerBarManager.foodBar.maxValue);
        hungerBarManager.SetFood(f);
    }

    public void Smell()
    {
        Debug.Log("Smell Pressed");
        Describe(Sense.Smell);
        SpendTime(2f);
        ChangeFood(-2f);
    }

    public void Listen()
    {
        Debug.Log("Listen Pressed");
        Describe(Sense.Listen);
        SpendTime(2f);
        ChangeFood(-2f);
    }

    public void Touch()
    {
        Debug.Log("Touch Pressed");
        Describe(Sense.Touch);
        SpendTime(2f);
        ChangeFood(-3f);
    }

    public void Look()
    {
        Debug.Log("Look Pressed");
        Describe(Sense.Look);
        SpendTime(3f);
        ChangeFood(-4f);
    }

    public void Eat()
    {
        Debug.Log("Eat Pressed");
        ChangeFood(CurrentFood().nutrition);

        if (locationIndex >= locations.Length - 1)
        {
            WriteLine("You’ve reached the Alley. No further paths ahead.");
            hungerBarManager.SetTime(0f);
            return;
        }

        SpendTime(2f);
        locationIndex += 1;
        UpdateBackground();
        WriteLine("You devour the food. You move on looking for more food.");
    }

    public void Move()
    {
        Debug.Log("Move Pressed");
        if (locationIndex >= locations.Length - 1)
        {
            WriteLine("You’ve reached the Alley. No further paths ahead.");
            hungerBarManager.timeBar.value = 0;
            return;
        }

        hungerBarManager.timeBar.value -= 2;
        ChangeFood(-2f);
        locationIndex += 1;
        WriteLine("You move on looking for food.");
        UpdateBackground();
    }

    private void UpdateBackground()
    {
        Location loc = CurrentLocation();
        if (loc == null) return;

        Sprite s = loc.backgroundSprite;

        if (backgroundRenderer != null)
        {
            backgroundRenderer.sprite = s;
        }

        if (backgroundImage != null)
        {
            backgroundImage.sprite = s;
            // Optional: match source sprite size
            // backgroundImage.SetNativeSize();
        }
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
    public float nutrition = 5f;
}

[Serializable]
public class Location
{
    public string locationName;
    public Food food = new Food();
    public Sprite backgroundSprite;

    public Location(string name)
    {
        locationName = name;
    }
}


