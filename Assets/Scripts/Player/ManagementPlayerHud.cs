using UnityEngine;
using UnityEngine.UI;

public class ManagementPlayerHud : MonoBehaviour
{
    public ManagementPlayer managementPlayer;
    public MiniMapInfo minimapInfo;

    void Update()
    {
        minimapInfo.directionPlayer.transform.localRotation = Quaternion.Euler(0,0,-Camera.main.transform.rotation.eulerAngles.y);
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

    [System.Serializable] public class MiniMapInfo{
        public Image directionPlayer;
        public MiniMap[] miniMaps;
    }
    [System.Serializable] public class MiniMap{
        public Image minimapImage;
        public GameObject gameObject;
    }
}
