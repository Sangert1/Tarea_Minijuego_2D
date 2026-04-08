using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int idMisionNivel;
    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void Salir()
    {
        Debug.Log("Cerrando aplicación...");
        Application.Quit();
    }



    void Start()
    {
        MissionManager.Instance.ConfigurarMision(idMisionNivel);
        Object.FindFirstObjectByType<ItemSpawner>().SpawnearNivel();
    }
}

