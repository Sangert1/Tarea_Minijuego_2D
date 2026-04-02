using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Paneles de Interfaz")]
    public GameObject panelInstrucciones;

    void Start()
    {

        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);
    }


    public void BotonJugar()
    {


        GameManager.Instance.CargarEscena("Nivel1");
    }


    public void AlternarInstrucciones(bool estado)
    {
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(estado);
    }


    public void BotonSalir()
    {

        GameManager.Instance.Salir();
    }
}

