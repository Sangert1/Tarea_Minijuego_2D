using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class ItemRecolectable : MonoBehaviour
{
    private string id;
    private int valor;


    public void Configurar(Coleccionable datos)
    {
        id = datos.iconoId;
        valor = datos.valor;


        Sprite spriteCargado = Resources.Load<Sprite>("Fruits/" + id);

        if (spriteCargado != null)
        {
            GetComponent<SpriteRenderer>().sprite = spriteCargado;
        }
        else
        {
            Debug.LogError($"[Item] No se encontró el sprite en Resources/Fruits/{id}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            GameManager.Instance.RegistrarRecoleccion(id, valor);


            Debug.Log($"¡Atrapaste un {id}! Vale {valor} puntos.");

            Destroy(gameObject);
        }
    }
}

