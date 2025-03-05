using UnityEngine;

public class ManagementCure : MonoBehaviour
{
    public GameObject room;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
