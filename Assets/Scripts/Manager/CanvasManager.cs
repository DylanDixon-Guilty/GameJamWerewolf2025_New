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

    public void ShowCanvasGameplay()
    {
        Instantiate(Resources.Load("Canvas/" + "Canvas_Gameplay") as GameObject);
    }

    public void ShowCanvasOptions()
    {
        Instantiate(Resources.Load("Canvas/" + "OptionsMenu") as GameObject);
    }

    public void ShowCanvasEndDead()
    {
        Instantiate(Resources.Load("Canvas/" + "End_Dead") as GameObject);
    }

    public void ShowCanvasEndGood()
    {
        Instantiate(Resources.Load("Canvas/" + "End_HumansAte") as GameObject);
    }

    public void ShowCanvasEndBad()
    {
        Instantiate(Resources.Load("Canvas/" + "End_NoHumansAte") as GameObject);
    }
}
