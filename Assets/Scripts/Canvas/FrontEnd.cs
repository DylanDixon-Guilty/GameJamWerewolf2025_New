using UnityEngine;

/// <summary>
/// Canvas: Input: FrontEnd buttons and functionality
/// </summary>

public class FrontEnd : MonoBehaviour
{
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

    public void OnNewGamePressed()
    {
        Debug.Log("New Game Pressed");
        CanvasManager.Instance.ShowCanvasGameplay();
    }


}
