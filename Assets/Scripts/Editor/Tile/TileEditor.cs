using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tile))]
public class TileEditor : Editor
{
    private Tile tgt;


    private void OnEnable()
    {
        tgt = (Tile)target;
    }

    private void OnSceneGUI()
    {
        Handles.BeginGUI();
        Handles.EndGUI();
    }

    private void DrawButton(string text, Vector3 pos, Vector3 dir)
    {
        var _pos = Camera.current.WorldToScreenPoint(pos);
        var size = 200 / Vector3.Distance(Camera.current.transform.position, pos);
        var rect = new Rect(pos.x - size / 2, Screen.height - pos.y - size, size, size /2);

        if (GUI.Button(rect, text))
        {
            Tile t = new Tile();
            switch(PrefabWindow.prefab)
            {
                case "PuertaDoble":
                    t = (Tile)Resources.Load("Prefabs/PuertaDoble", typeof(Tile));
                    break;
                case "PuertaDobleAbierta":
                    t = (Tile)Resources.Load("Prefabs/PuertaDobleAbierta", typeof(Tile));
                    break;
                case "Arco":
                    t = (Tile)Resources.Load("Prefabs/Arco", typeof(Tile));
                    break;
                case "Piso":
                    t = (Tile)Resources.Load("Prefabs/Piso", typeof(Tile));
                    break;
                case "ParedConcava":
                    t = (Tile)Resources.Load("Prefabs/ParedConcava", typeof(Tile));
                    break;
                case "ParedConvexa":
                    t = (Tile)Resources.Load("Prefabs/ParedConvexa", typeof(Tile));
                    break;
                case "Pared":
                    t = (Tile)Resources.Load("Prefabs/Pared", typeof(Tile));
                    break;
            }
            Tile _tile = Instantiate(t);
            t.transform.forward = (dir - tgt.transform.position).normalized;
            t.transform.position = dir + (_tile.transform.forward.normalized * 3f);
            Selection.activeObject = t;
            SceneView.lastActiveSceneView.LookAt(t.transform.position);
        }
    }
}
