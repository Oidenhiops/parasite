using UnityEngine;
using UnityEngine.UI;

public class ManagementDetector : MonoBehaviour
{
    public Image fillBar;
    public float max;
    public float current;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objects"))
        {
            //Implementar efecto de particulas aquí
            current += 3;
            if (current > max) current = max;
            fillBar.fillAmount = current / max;
        }
    }
}
