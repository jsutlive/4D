using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for all UI elements in the scene. To be refactored into smaller components
/// </summary>
public class UIScreenManager : MonoBehaviour
{
    [SerializeField]
    Text gameStateText;

    [SerializeField]
    GameObject gameStatePanel;

    [SerializeField]
    GameObject rewindEffectPanel;

    private void OnEnable()
    {
        GameEvents.OnRewind += AddRewindScreen;
        GameEvents.OnStopRewind += RemoveRewindScreen;
        GameEvents.OnWin += AddPlayerWinScreen;
        GameEvents.OnParadox += AddPlayerParadoxScreen;
    }

    private void AddPlayerParadoxScreen()
    {
        gameStatePanel.SetActive(true);
        gameStateText.text = "Paradox!";        
    }

    public void Retry() => GameEvents.Reload();

    public void Quit() => GameEvents.Quit();
     
    private void AddPlayerWinScreen()
    {
        gameStatePanel.SetActive(true);
        gameStateText.text = "You Win";
    }

    private void RemoveRewindScreen()
    {
        rewindEffectPanel.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvents.OnRewind -= AddRewindScreen;
        GameEvents.OnStopRewind -= RemoveRewindScreen;
        GameEvents.OnWin -= AddPlayerWinScreen;
        GameEvents.OnParadox -= AddPlayerParadoxScreen;
    }

    private void AddRewindScreen()
    {
        rewindEffectPanel.SetActive(true);
    }
}
