using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int scoreTotal = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }

    public void RegistrarRecoleccion(string nombre, int valor)
    {
        scoreTotal += valor;

        Debug.Log($"<color=green>Recolectado:</color> {nombre} | <color=yellow>Valor:</color> {valor}");

        if (UIManager.Instance != null) UIManager.Instance.ActualizarPuntajeUI(scoreTotal);
        if (MissionManager.Instance != null) MissionManager.Instance.VerificarProgreso(nombre);
    }

    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Debug.Log("Cerrando aplicación...");
        Application.Quit();
    }
}
