using System.Linq;
using UnityEngine;

public class ManagementSpawnCures : MonoBehaviour
{
    public ManagementCure[] managementCures;
    public float timeToChange = 0;
    public float timeToChangeMax = 5;
    public ManagementCure currentCure;
    public ManagementPlayer managementPlayer;
    public void Start()
    {
        timeToChange = timeToChangeMax;
        currentCure = managementCures[Random.Range(0, managementCures.Count())];
        currentCure.gameObject.SetActive(true);
        managementPlayer.managementPlayerHud.ChangeCurrentCure(currentCure.room);
    }
    void Update()
    {
        timeToChange -= Time.deltaTime;
        if (timeToChange <= 0 || !currentCure.gameObject.activeSelf)
        {
            timeToChange = timeToChangeMax;
            ChangeCure();
        }
    }
    public void ChangeCure()
    {        
        ManagementCure cureTarget = currentCure;
        while (cureTarget == currentCure){
            cureTarget = managementCures[Random.Range(0, managementCures.Count())];
        }
        currentCure.gameObject.SetActive(false);
        currentCure = cureTarget;
        currentCure.gameObject.SetActive(true);
        managementPlayer.managementPlayerHud.ChangeCurrentCure(currentCure.room);
    }
}
