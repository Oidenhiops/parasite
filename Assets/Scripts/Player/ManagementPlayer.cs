using System.Collections;
using UnityEngine;

public class ManagementPlayer : MonoBehaviour
{
    public bool isActive;
    public PlayerMovement playerMovement;
    public ManagementPlayerInputs managementPlayerInputs;
    public ManagementPlayerHud managementPlayerHud;
    public int totalTime = 300;

    void Update()
    {
        if (isActive){
            playerMovement.Move();
        }
    }
}
