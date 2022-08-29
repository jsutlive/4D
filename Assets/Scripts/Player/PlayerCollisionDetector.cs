using UnityEngine;

/// <summary>
/// When two player objects collide, a game-ending paradox is created.
/// </summary>
public class PlayerCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.InitiateParadox();
        }
    }
}
