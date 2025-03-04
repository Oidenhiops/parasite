using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ManagementPlayer managementPlayer;
    public Rigidbody rb;
    public Vector3 movementDirection;
    public GameObject model;
    Vector3 camForward;
    Vector3 camRight;
    public float speed;
    public float lerpSpeed;
    public void Move()
    {
        Vector3 inputs = new Vector3(managementPlayer.managementPlayerInputs.playerInputs.movement.x, 0, managementPlayer.managementPlayerInputs.playerInputs.movement.y);
        if (inputs != Vector3.zero)
        {
            CamDirection();
            Vector3 camDirection = (inputs.x * camRight + inputs.z * camForward).normalized;
            movementDirection = new Vector3(camDirection.x * speed, rb.linearVelocity.y, camDirection.z * speed);
            
            rb.linearVelocity = movementDirection;
        }
        RotateModel();
    }
    void CamDirection()
    {
        Vector3 camForwardDirection = Camera.main.transform.forward;
        Vector3 camRightDirection = Camera.main.transform.right;

        camForwardDirection.y = 0;
        camRightDirection.y = 0;

        camForward = camForwardDirection.normalized;
        camRight = camRightDirection.normalized;
    }
    void RotateModel()
    {
        float angle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, Quaternion.Euler(0, angle, 0f), lerpSpeed);
    }
}
