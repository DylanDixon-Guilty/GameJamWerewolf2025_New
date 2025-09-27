using UnityEngine;


/// <summary>
/// Canvas: Input: Title-Screen buttons and functionality
/// </summary>

public class TitleScreen : MonoBehaviour
{
    public void OnPressStartClicked()
    {
        Debug.Log("<color=green>Play Now Clicked</color>");
        CanvasManager.Instance.ShowCanvasFrontEnd();
    }
}
