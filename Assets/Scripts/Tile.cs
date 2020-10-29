using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileName
    {
        PuertaDoble,
        PuertaDobleAbierta,
        Arco,
        Piso,
        ParedConcava,
        ParedConvexa,
        Pared,
        Fin
    }

    //public List<string> TileNames = new List<string>() 
    //{ "PuertaDoble", "PuertaDobleAbierta", "Arco", "Piso", "ParedConcava", "ParedConvexa", "Pared" };

    public TileName currentTileName
    {
        get
        {
            var gameObjectName = gameObject.name;
            if (gameObjectName.Contains("PuertaDoble")) return TileName.PuertaDoble;
            if (gameObjectName.Contains("PuertaDobleAbierta")) return TileName.PuertaDobleAbierta;
            if (gameObjectName.Contains("Arco")) return TileName.Arco;
            if (gameObjectName.Contains("Piso")) return TileName.Piso;
            if (gameObjectName.Contains("ParedConvexa")) return TileName.ParedConvexa;
            if (gameObjectName.Contains("ParedConcava")) return TileName.ParedConcava;
            else return TileName.Pared;

        }
    }
}
