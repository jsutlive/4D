using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles collection of time points and animatiion of non-controllable entities which are rewound
/// </summary>
public class RewindController : MonoBehaviour
{
    [SerializeField, Tooltip("List of timepoints made visible in inspector for debugging")]
    List<TimePoint> timePoints = new List<TimePoint>();

    [SerializeField, Tooltip("Rigidbody in the children of this prefab")]
    Rigidbody rb;

    // max number of frames to rewind
    int timePointsCount = 500;
    // current frame this object is on in its rewind cycle
    int currentTimePointCount;

    public bool isRewinding = false;

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

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            // rewind time
            RewindTimePoints();
        }
        else
        {
            // move forward in time automatically if this is a clone (i.e., no player control)
            if (GetComponent<PlayerController>() == null)
            {
                if (currentTimePointCount < timePoints.Count)
                {
                    SetTimePointForward(timePoints[currentTimePointCount]);
                    currentTimePointCount++;
                }
                else
                    SetTimePointForward(new TimePoint(transform.position, new Vector3(0f, 0f, 0f)));
            }
            // record player's movement
            else RecordTimePoints();
        }
    }

    private void RewindTimePoints()
    {
        if(timePoints.Count > 0)
        {
            currentTimePointCount--;
            SetTimePointReverse(timePoints[currentTimePointCount]);
        }
        else
        {
            StopRewinding();
        }
    }

    private void RecordTimePoints()
    {
        if (timePoints.Count >= timePointsCount) timePoints.RemoveAt(0);
        timePoints.Add(new TimePoint(transform.position, rb.velocity));
        currentTimePointCount = timePoints.Count;
    }
    
    // Move this object backwards based on time point
    private void SetTimePointReverse(TimePoint timePoint)
    {
        transform.position = timePoint.position;
        rb.velocity = -1f * timePoint.velocity;
    }

    //move this object forwards based on time point
    private void SetTimePointForward(TimePoint timePoint)
    {
        transform.position = timePoint.position;
        rb.velocity = timePoint.velocity;
    }

    private void RewindTime()
    {
        isRewinding = true;
    }   

    private void StopRewinding()
    {
        isRewinding = false;
    }
}
