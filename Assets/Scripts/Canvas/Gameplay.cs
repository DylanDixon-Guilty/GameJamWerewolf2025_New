using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public void Smell()
    {
        Debug.Log("Smell Pressed");
    }

    public void Listen()
    {
        Debug.Log("Listen Pressed");
    }

    public void Touch()
    {
        Debug.Log("Touch Pressed");
    }

    public void Look()
    {
        Debug.Log("Look Pressed");
    }

    public void Eat()
    {
        Debug.Log("Eat Pressed");
    }

    public void Move()
    {
        Debug.Log("Move Pressed");
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
}
