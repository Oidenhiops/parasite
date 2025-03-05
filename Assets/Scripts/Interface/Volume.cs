using UnityEngine;
using UnityEngine.UI;
public class Volume : MonoBehaviour
{
    public Slider slider;
    public Image imageMute;

    //carga el volumen guardado y lo aplica al audio del juego.
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        VerMute();
    }

    //actualiza el volumen del juego cuando el usuario ajusta el slider.
    public void ChangeSlider(float valor)
    {
        PlayerPrefs.SetFloat("volumenAudio", slider.value);
        AudioListener.volume = slider.value;
        VerMute();
    }
    
    //controla la visibilidad del icono de muteo según el volumen del juego.
    public void VerMute()
    {
        if (slider.value == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }

}
