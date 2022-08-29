using UnityEngine;

/// <summary>
/// Change material on player when player starts rewinding.
/// </summary>
public class PlayerMaterialChanger : MonoBehaviour, IChangeMaterial
{
    [SerializeField]
    Material defaultMaterial;

    [SerializeField]
    Material cloneMaterial;

    public void ChangeToMaterialA()
    {
        GetComponentInChildren<MeshRenderer>().material = defaultMaterial;
    }

    public void ChangeToMaterialB()
    {
        GetComponentInChildren<MeshRenderer>().material = cloneMaterial;
    }

    private void OnEnable()
    {
        GameEvents.OnRewind += ChangeToMaterialA;
    }

    private void OnDisable()
    {
        GameEvents.OnRewind -= ChangeToMaterialA;
    }
}
