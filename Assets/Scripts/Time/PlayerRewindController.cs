using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindController : RewindController
{ 
    private void FixedUpdate()
    {
        // record player's movement when not rewinding
        if (!isRewinding) RecordTimePoints();
    }

    private void RecordTimePoints()
    {
        if (timePoints.Count >= timePointsCount) timePoints.RemoveAt(0);
        timePoints.Add(new TimePoint(rb.gameObject.transform.position, rb.velocity));
        currentTimePointCount = timePoints.Count;
    }

}
