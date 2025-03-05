using UnityEngine;

public class ManagementDoor : MonoBehaviour
{
    public GameObject door;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RigthHand"))
        {
            door.GetComponent<Animator>().SetBool("IsActive", true);
        }
    }
}
