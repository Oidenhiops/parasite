using UnityEngine;

public class ManagementPlayer : MonoBehaviour
{
    public bool isActive;
    public PlayerMovement playerMovement;
    public ManagementPlayerInputs managementPlayerInputs;

    void Update()
    {
        if (isActive){
            playerMovement.Move();
        }
    }
}
