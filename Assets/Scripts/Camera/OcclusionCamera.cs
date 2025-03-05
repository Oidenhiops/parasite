using UnityEngine;

public class OcclusionCamera : MonoBehaviour
{
    public Color occlusionColor;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
