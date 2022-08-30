using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles collection of time points and animatiion of non-controllable entities which are rewound
/// </summary>
public abstract class RewindController : MonoBehaviour
{
    [SerializeField, Tooltip("List of timepoints made visible in inspector for debugging")]
    protected List<TimePoint> timePoints = new List<TimePoint>();
    public List<TimePoint> GetTimePoints() => timePoints;

    [SerializeField, Tooltip("Rigidbody in the children of this prefab")]
    protected Rigidbody rb;

    // max number of frames to rewind
    protected int timePointsCount = 500;
    // current frame this object is on in its rewind cycle
    protected int currentTimePointCount;

    protected bool isRewinding = false;
   

    private void OnEnable()
    {
        GameEvents.OnRewind += RewindTime;
        GameEvents.OnStopRewind += StopRewinding;
    }

    private void OnDisable()
    {
        GameEvents.OnRewind -= RewindTime;
        GameEvents.OnStopRewind -= StopRewinding;
    }

    protected void RewindTime()
    {
        GetComponentInChildren<SphereCollider>().enabled = false;
        isRewinding = true;
    }

    protected void StopRewinding()
    {
        GetComponentInChildren<SphereCollider>().enabled = true;
        isRewinding = false;
    }
}
