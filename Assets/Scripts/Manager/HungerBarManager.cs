using UnityEngine;
using UnityEngine.UI;

public class HungerBarManager : MonoBehaviour
{
    public static HungerBarManager Instance { get; private set; }

    public Slider foodBar;
    public Slider timeBar;
    public bool humanAte = false;

    private int hungerThreshold = 4; // The amount of hunger you need to not starve

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void SetMaxFood(float value)
    {
        foodBar.maxValue = value;
        foodBar.value = value;
    }

    public void SetMaxTime(float value)
    {
        timeBar.maxValue = value;
        timeBar.value = value;
    }

    public void SetFood(float food)
    {
        foodBar.value = food;
    }

    public void SetTime(float time)
    {
        timeBar.value = time;
    }

    private void Update()
    {
        if (timeBar.value == 0 && foodBar.value < hungerThreshold)
        {
            Debug.Log("Game Over: You starved!");
            CanvasManager.Instance.ShowCanvasEndDead();
            Destroy(this.gameObject);
        }
        if (timeBar.value == 0 && foodBar.value >= hungerThreshold)
        {
            Debug.Log("Game Over: You Lived!");
            if (!humanAte)
            {
                Debug.Log("But you didn't eat any humans, you monster!");
                CanvasManager.Instance.ShowCanvasEndGood();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("You ate a human, you monster!");
                CanvasManager.Instance.ShowCanvasEndBad();
                Destroy(this.gameObject);
            }
        }
    }
}
