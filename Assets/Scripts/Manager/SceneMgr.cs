using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public enum eScene { frontEnd, inGame }
public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
        Debug.Log("<color=yellow>Scene Loaded: " + _scene.name + "</color>");

        switch ((eScene)_scene.buildIndex)
        {
            case eScene.frontEnd:
                CanvasManager.Instance.ShowCanvasTitleScreen();
                break;
        }
    }
}
