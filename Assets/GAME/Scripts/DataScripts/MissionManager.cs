using UnityEngine;
using System.Linq;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;
    public Mision misionActual;

    void Awake() { Instance = this; }

    public void ConfigurarMision(int id)
    {
        misionActual = GameDataLoader.Instance.dataMisiones.misiones.Find(m => m.id == id);
        if (misionActual != null)
        {
            foreach (var obj in misionActual.objetivos) obj.actual = 0;
            UIManager.Instance.ActualizarListaUI(misionActual);
        }
    }

    public void VerificarProgreso(string itemName)
    {
        var obj = misionActual.objetivos.Find(o => o.itemName.ToLower() == itemName.ToLower());
        if (obj != null)
        {
            obj.actual++;
            UIManager.Instance.ActualizarListaUI(misionActual);
            ChequearVictoria();
        }
    }

    void ChequearVictoria()
    {
        if (misionActual.objetivos.All(o => o.actual >= o.cantidad))
        {
            UIManager.Instance.ActivarPanelVictoria();
        }
    }
}
