using System;
using UnityEngine;

/// <summary>
/// Class to record position and rigidbody velocity data
/// </summary>
[Serializable]
public class TimePoint
{
    public Vector3 position;
    public Vector3 velocity;

    public TimePoint(Vector3 position, Vector3 velocity)
    {
        this.position = position;
        this.velocity = velocity;
    }
}
