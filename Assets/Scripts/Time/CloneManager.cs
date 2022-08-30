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

    [SerializeField, Tooltip("Root transform to spawn clone")]
    Transform cloneRoot;

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
        Instantiate(cloneObject, cloneRoot.position, cloneRoot.rotation);
    }
}
