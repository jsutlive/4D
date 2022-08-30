using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Win condition upon trigger conditions met. To be generified later
/// </summary>
public class WinTriggerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponent<ObjectMaterialChanger>().Activated()) return;
        if (other.gameObject.CompareTag("Player"))
        {
            GameEvents.Win();
        }
    }
}
