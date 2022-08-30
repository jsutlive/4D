using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides functionality to change material from one material to another
/// </summary>
public class ObjectMaterialChanger : MonoBehaviour, IChangeMaterial
{
    [SerializeField]
    Material materialA;

    [SerializeField]
    Material materialB;

    bool activated;
    public bool Activated() => activated;

    public void ChangeToMaterialA()
    {
        GetComponent<MeshRenderer>().material = materialA;
        activated = false;
    }

    public void ChangeToMaterialB()
    {
        GetComponent<MeshRenderer>().material = materialB;
        activated = true;
    }    

}
