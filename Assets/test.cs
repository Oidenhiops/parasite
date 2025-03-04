using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject door;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("RigthHand"))
        {
            door.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RigthHand"))
        {
            door.SetActive(false);
        }
    }
}
