using UnityEngine;

public class ManagementClock : MonoBehaviour
{
    public float currentTimeToAppear;
    public float timeToAppear;
    public GameObject clock;
    void Start()
    {
        currentTimeToAppear = timeToAppear;
    }
    void Update()
    {
        if (!clock.activeSelf)
        {
            currentTimeToAppear -= Time.deltaTime;
            if (currentTimeToAppear <= 0)
            {
                currentTimeToAppear = timeToAppear;
                clock.SetActive(true);
                GetComponent<Collider>().enabled = true;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("RigthHand"))
        {
            clock.SetActive(false);
            GetComponent<Collider>().enabled = false;
            other.transform.root.GetComponent<ManagementPlayer>().managementPlayerHud.UpdateSeconds(10);
        }
    }
}
