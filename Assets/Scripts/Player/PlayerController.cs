using UnityEngine;

/// <summary>
/// Handles player input and basic movement physics
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    [SerializeField]
    RewindController rewindController;

    Vector3 velocity, desiredVelocity;

    // Update is called once per frame
    private void Update()
    {
        Vector2 playerInput = Vector2.zero;

#region REWIND_CONTROLS
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEvents.Rewind();
        } 
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GameEvents.StopRewind();
        }
        #endregion REWIND_CONTROLS

#region MOVEMENT_CONTROLS
        if (!Input.GetKey(KeyCode.Space))
        {
            playerInput.x = Input.GetAxis("Horizontal");
            playerInput.y = Input.GetAxis("Vertical");
            playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        }
#endregion MOVEMENT_CONTROLS

        desiredVelocity = new Vector3(playerInput.x, 0, playerInput.y) * maxSpeed;
    }

    // adjust rigidbody velocity based on player input, speed, and acceleration constraints.
    private void FixedUpdate()
    {   
        velocity = rb.velocity;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        rb.velocity = velocity;       
    }
}
