using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Configuración de Prefabs")]
    public GameObject prefabFruta;

    [Header("Puntos de Spawn")]
    public Transform[] puntos;

    public void SpawnearNivel()
    {

        if (MissionManager.Instance.misionActual == null)
        {
            Debug.LogError("[Spawner] No hay una misión cargada en el MissionManager.");
            return;
        }

        Mision m = MissionManager.Instance.misionActual;

        for (int i = 0; i < puntos.Length; i++)
        {

            string idFruta = m.objetivos[i % m.objetivos.Count].itemName;


            Coleccionable datos = GameDataLoader.Instance.dataColeccionables.coleccionables.Find(x => x.iconoId == idFruta);

            if (datos != null)
            {

                GameObject go = Instantiate(prefabFruta, puntos[i].position, Quaternion.identity);


                go.GetComponent<ItemRecolectable>().Configurar(datos);
            }
            else
            {
                Debug.LogWarning($"[Spawner] No se encontraron datos para la fruta: {idFruta}");
            }
        }
    }
}
