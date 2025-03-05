using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagementPlayerHud : MonoBehaviour
{
    public ManagementPlayer managementPlayer;
    public MiniMapInfo minimapInfo;
    public TMP_Text timer;
    public int totalSeconds = 300;
    public int currentPoints;
    public TMP_Text points;
    public GameObject endMenu;
    public TMP_Text pointsEnd;
    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        minimapInfo.directionPlayer.transform.localRotation = Quaternion.Euler(0, 0, -Camera.main.transform.rotation.eulerAngles.y);
    }

    public void ChangeCurrentPosition(GameObject gameObject)
    {
        foreach (var miniMap in minimapInfo.miniMaps)
        {
            if (miniMap.gameObject == gameObject)
            {
                minimapInfo.directionPlayer.transform.SetParent(miniMap.minimapImage.transform);
                minimapInfo.directionPlayer.transform.localPosition = Vector3.zero;
            }
        }
    }
    public void ChangeCurrentCure(GameObject room)
    {
        foreach (var miniMap in minimapInfo.miniMaps)
        {
            if (miniMap.gameObject == room)
            {
                miniMap.minimapImage.color = Color.yellow;
            }
            else
            {
                miniMap.minimapImage.color = Color.white;

            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniMap"))
        {
            ChangeCurrentPosition(other.gameObject);
        }
    }

    [System.Serializable]
    public class MiniMapInfo
    {
        public Image directionPlayer;
        public MiniMap[] miniMaps;
    }
    [System.Serializable]
    public class MiniMap
    {
        public Image minimapImage;
        public GameObject gameObject;
    }
    public IEnumerator Timer()
    {
        while (totalSeconds > 0)
        {
            string timeFormatted = string.Format("{0:D2}:{1:D2}", totalSeconds / 60, totalSeconds % 60);
            timer.text = timeFormatted;
            totalSeconds -= 1;
            yield return new WaitForSeconds(1);
        }
        pointsEnd.text = managementPlayer.managementPlayerHud.currentPoints.ToString();
        endMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void UpdateSeconds(int plus)
    {
        totalSeconds += plus;
        string timeFormatted = string.Format("{0:D2}:{1:D2}", totalSeconds / 60, totalSeconds % 60);
        timer.text = timeFormatted;
    }
    public void AddPoints(int plus){
        currentPoints += plus;
        points.text = "Points: " + currentPoints;
    }
}
