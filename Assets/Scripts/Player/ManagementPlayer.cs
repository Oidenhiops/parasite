using UnityEngine;

public class ManagementPlayer : MonoBehaviour
{
    public bool isActive;
    public PlayerMovement playerMovement;
    public ManagementPlayerInputs managementPlayerInputs;
    public ManagementPlayerHud managementPlayerHud;
    void Update()
    {
        if (isActive){
            playerMovement.Move();
        }
    }
}
