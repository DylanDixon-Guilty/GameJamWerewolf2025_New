using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    void Start()
    {
        Debug.Log("Starting Game");
        Debug.Log("Push Test");
    }

    private void StartPressed()
    {
        Debug.Log("Start Pressed");
    }

    private void QuitPressed()
    {
        Debug.Log("Quit Pressed");
        Application.Quit();
    }

    private void Options()
    {
        Debug.Log("Options Pressed");
    }

    private void Smell()
    {
        Debug.Log("Smell Pressed");
    }

    private void Listen()
    {
        Debug.Log("Listen Pressed");
    }

    private void Touch()
    {
        Debug.Log("Touch Pressed");
    }

    private void Look()
    {
        Debug.Log("Look Pressed");
    }

    private void Eat()
    {
        Debug.Log("Eat Pressed");
    }

    private void Move()
    {
        Debug.Log("Move Pressed");
    }
}
