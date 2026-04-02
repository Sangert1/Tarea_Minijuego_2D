using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int idMisionNivel;


    void Start()
    {
        MissionManager.Instance.ConfigurarMision(idMisionNivel);
        FindObjectOfType<ItemSpawner>().SpawnearNivel();
    }
}
