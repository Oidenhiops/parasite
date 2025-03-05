using UnityEngine;

public class ManagementDoor : MonoBehaviour
{
    public GameObject door;
    public float maxTime = 15;
    public float currentTime;
    public bool isPushed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPushed)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                isPushed = false;
                door.GetComponent<Animator>().SetBool("IsActive", false);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RigthHand") && !isPushed)
        {
            isPushed = true;
            currentTime = maxTime;
            door.GetComponent<Animator>().SetBool("IsActive", true);
        }
    }
}
