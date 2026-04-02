using UnityEngine;
using System.IO;

public class GameDataLoader : MonoBehaviour
{
    public static GameDataLoader Instance;
    public ColeccionablesWrapper dataColeccionables;
    public MisionesWrapper dataMisiones;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CargarArchivos();
        }
        else { Destroy(gameObject); }
    }

    void CargarArchivos()
    {
        string pathCol = Path.Combine(Application.streamingAssetsPath, "Coleccionables.json");
        string pathMis = Path.Combine(Application.streamingAssetsPath, "Misiones.json");

        if (File.Exists(pathCol))
        {
            string json = File.ReadAllText(pathCol);
            dataColeccionables = JsonUtility.FromJson<ColeccionablesWrapper>("{\"coleccionables\":" + json + "}");
        }
        if (File.Exists(pathMis))
        {
            string json = File.ReadAllText(pathMis);
            dataMisiones = JsonUtility.FromJson<MisionesWrapper>("{\"misiones\":" + json + "}");
        }
    }
}
