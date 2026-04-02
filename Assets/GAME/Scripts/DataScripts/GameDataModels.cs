using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coleccionable
{
    public string iconoId;
    public string nombre;
    public string rareza;
    public int valor;
}

[System.Serializable]
public class Objetivo
{
    public string itemName;
    public int cantidad;
    [HideInInspector] public int actual = 0;
}

[System.Serializable]
public class Mision
{
    public int id;
    public string titulo;
    public List<Objetivo> objetivos;
}

[System.Serializable]
public class ColeccionablesWrapper { public List<Coleccionable> coleccionables; }
[System.Serializable]
public class MisionesWrapper { public List<Mision> misiones; }
