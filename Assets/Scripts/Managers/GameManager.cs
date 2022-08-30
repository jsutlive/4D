using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main game manager. Controls physics state, level loading, etc. Some components to be refactored.
/// </summary>
public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        LoadScenes();
    }

    void LoadScenes()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    void ReloadAll()
    {
        SceneManager.LoadScene(0);
    }

    void EliminateGravity()
    {
        Physics.gravity = new Vector3(0f, 0f, 0f);
    }

    void ReinstateGravity()
    {
        Physics.gravity = new Vector3(0f, -9.8f, 0f);
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnEnable()
    {
        GameEvents.OnRewind += EliminateGravity;
        GameEvents.OnStopRewind += ReinstateGravity;
        GameEvents.OnReload += ReloadAll;
        GameEvents.OnQuit += Quit;
    }

    private void OnDisable()
    {
        GameEvents.OnReload -= ReloadAll;
        GameEvents.OnQuit -= Quit;
        GameEvents.OnRewind -= EliminateGravity;
        GameEvents.OnStopRewind -= ReinstateGravity;
    }
}
