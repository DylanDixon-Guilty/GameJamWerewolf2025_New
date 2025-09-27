using UnityEngine;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Method that display the front end canvas
    /// </summary>
    public void ShowCanvasTitleScreen()
    {
        Instantiate(Resources.Load("Canvas/" + "Canvas_TitleScreen") as GameObject);
    }

    public void ShowCanvasFrontEnd()
    {
        Instantiate(Resources.Load("Canvas/" + "Canvas_FrontEnd") as GameObject);
    }
}
