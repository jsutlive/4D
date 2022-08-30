using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindAnimator : RewindController
{
    PlayerRewindController player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRewindController>();
        isRewinding = true;
        timePoints = new List<TimePoint>(player.GetTimePoints());
        currentTimePointCount = timePoints.Count;        
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
            if (currentTimePointCount < timePoints.Count)
            {
                SetTimePointForward(timePoints[currentTimePointCount]);
                currentTimePointCount++;
            }
            else
            {
                SetTimePointForward(new TimePoint(rb.gameObject.transform.position, new Vector3(0f, 0f, 0f)));
            }
        }
    }

    private void RewindTimePoints()
    {
        if (currentTimePointCount > 0)
        {
            currentTimePointCount--;
            SetTimePointReverse(timePoints[currentTimePointCount]);
        }
        else
        {
            StopRewinding();
        }
    }

    // Move this object backwards based on time point
    private void SetTimePointReverse(TimePoint timePoint)
    {
        rb.gameObject.transform.position = timePoint.position;
        rb.velocity = -1f * timePoint.velocity;
    }

    //move this object forwards based on time point
    private void SetTimePointForward(TimePoint timePoint)
    {
        rb.gameObject.transform.position = timePoint.position;
        rb.velocity = timePoint.velocity;
    }   
}
