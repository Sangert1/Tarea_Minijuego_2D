using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI txtPuntaje;
    public TextMeshProUGUI txtListaMisiones;
    public GameObject panelVictoria;

    void Awake() { Instance = this; panelVictoria.SetActive(false); }

    public void ActualizarPuntajeUI(int total)
    {
        txtPuntaje.text = "Puntos: " + total;
    }

    public void ActualizarListaUI(Mision m)
    {
        txtListaMisiones.text = $"<b>{m.titulo}</b>\n";
        foreach (var o in m.objetivos)
        {
            txtListaMisiones.text += $"{o.itemName}: {o.actual}/{o.cantidad}\n";
        }
    }

    public void ActivarPanelVictoria()
    {
        panelVictoria.SetActive(true);
    }

    public void BotonSiguiente()
    {

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex >= 2)
            GameManager.Instance.CargarEscena("MenuPrincipal");
        else
            GameManager.Instance.CargarEscena("Nivel2");
    }
}
