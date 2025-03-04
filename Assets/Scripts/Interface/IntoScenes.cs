using UnityEngine;

public class IntoScene : MonoBehaviour
{
    private void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsByType<IntoScene>(FindObjectsSortMode.None);
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
