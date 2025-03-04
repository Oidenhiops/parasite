using UnityEngine;

public class BrilloManager : MonoBehaviour
{
    public static BrilloManager Instance { get; private set; }
    private float brilloActual = 0.35f; // Brillo por defecto

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena

            // Cargar brillo almacenado si existe
            brilloActual = PlayerPrefs.GetFloat("Brillo", 0.35f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBrillo(float valor)
    {
        brilloActual = valor;
        PlayerPrefs.SetFloat("Brillo", brilloActual); // Guardar en memoria
        PlayerPrefs.Save();
    }

    public float GetBrillo()
    {
        return brilloActual;
    }
}
