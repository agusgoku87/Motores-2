using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.WSA;

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
        DrawButton(tgt.currentTileName.ToString(), tgt.transform.position, Vector3.zero);
        var value = 300 / Vector3.Distance(Camera.current.transform.position, tgt.transform.position);
        if(tgt.forward && (!Physics.Raycast(tgt.transform.position, tgt.transform.forward, 20)))
        {
            DrawButton("+", tgt.transform.position + tgt.transform.forward * value, tgt.forward.transform.position);
        }

        else if (tgt.right && (!Physics.Raycast(tgt.transform.position, tgt.transform.right, 20)))
        {
            DrawButton("+", tgt.transform.position + tgt.transform.right * value, tgt.right.transform.position);
        }

        else if (tgt.left && (!Physics.Raycast(tgt.transform.position, -tgt.transform.right, 20)))
        {
            DrawButton("+", tgt.transform.position - tgt.transform.right * value, tgt.left.transform.position);
        }
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
                case "Pared":
                    t = (Tile)Resources.Load("Pared", typeof(Tile));
                    break;
                case "Final":
                    t = (Tile)Resources.Load("Final", typeof(Tile));
                    break;
                case "Cruce":
                    t = (Tile)Resources.Load("Cruce", typeof(Tile));
                    break;
                case "ParedConcava":
                    t = (Tile)Resources.Load("ParedConcava", typeof(Tile));
                    break;
                case "PisoTecho":
                    t = (Tile)Resources.Load("PisoTecho", typeof(Tile));
                    break;
                case "PuertaAbierta":
                    t = (Tile)Resources.Load("PuertaAbierta", typeof(Tile));
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
