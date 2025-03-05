using UnityEngine;

public class ManagementCure : MonoBehaviour
{
    public GameObject room;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.root.GetComponent<ManagementPlayer>().managementPlayerHud.AddPoints(100);
            gameObject.SetActive(false);
        }
    }
}
