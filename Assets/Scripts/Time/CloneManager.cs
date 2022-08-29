using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates clones of objects due to rewinding
/// </summary>
public class CloneManager : MonoBehaviour
{
    [SerializeField, Tooltip("Object to be created as a clone of this object")]
    GameObject cloneObject;


    private void OnEnable()
    {
        GameEvents.OnRewind += CreateClone;
    }

    private void OnDisable()
    {
        GameEvents.OnRewind -= CreateClone;
    }

    private void CreateClone()
    {
        if (GetComponent<PlayerController>() != null)
        {
            Instantiate(cloneObject, transform.position, transform.rotation);
        }
        Destroy(GetComponent<PlayerController>());
    }
}
