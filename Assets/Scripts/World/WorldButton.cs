using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// When player enters the trigger space, invokes all methods in the enterTrigger unity event, 
/// likewise when player exits, all methods in exitTrigger are invoked
/// </summary>
public class WorldButton : MonoBehaviour
{
    [SerializeField]
    UnityEvent enterTrigger;

    [SerializeField]
    UnityEvent exitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enterTrigger?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            exitTrigger?.Invoke();
        }
    }
}
