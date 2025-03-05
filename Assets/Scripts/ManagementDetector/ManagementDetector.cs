using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagementDetector : MonoBehaviour
{
    public Image fillBar;
    public float max;
    public float current;
    public bool gameEnd = false;
    public GameObject endMenu;
    public ManagementPlayer managementPlayer;
    public TMP_Text pointsEnd;
    public GameObject audioSound;
    public AudioClip audioClip;

    void Update()
    {
        if (current >= max && !gameEnd)
        {
            gameEnd = true;
            pointsEnd.text = managementPlayer.managementPlayerHud.currentPoints.ToString();
            endMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objects"))
        {
            other.gameObject.tag = "Untagged";
            managementPlayer.managementPlayerHud.AddPoints(-20);
            GameObject audio = Instantiate(audioSound);
            audio.GetComponent<AudioSource>().clip = audioClip;
            Destroy(audio, audioClip.length);
            //Implementar efecto de particulas aquí
            current += 3;
            if (current > max) current = max;
            fillBar.fillAmount = current / max;
        }
    }
}
