using UnityEngine;
using UnityEngine.UI;

public class BrilloUI : MonoBehaviour
{
    public Slider slider;
    public Image panelBrillo;

    void Start()
    {
        if (BrilloManager.Instance != null)
        {
            float brilloGuardado = BrilloManager.Instance.GetBrillo();
            slider.value = brilloGuardado;
            UpdateBrightness(brilloGuardado);
        }

        slider.onValueChanged.AddListener(ChangeBrillo);
    }

    public void ChangeBrillo(float valor)
    {
        BrilloManager.Instance.SetBrillo(valor);
        UpdateBrightness(valor);
    }

    private void UpdateBrightness(float valor)
    {
        if (panelBrillo != null)
        {
            panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, valor);
        }
    }
}
