using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameData))]
public class GameDataEditor: Editor {

    GameData data;

    void OnEnable()
    {
        data = target as GameData;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Path - " + data.gamePath);
        if(GUILayout.Button("Browse"))
            data.gamePath = EditorUtility.OpenFilePanel("find the game", data.gamePath, "exe");
        EditorGUILayout.EndHorizontal();

        data.gameName = EditorGUILayout.TextField("Name", data.gameName);
        data.gameYear = EditorGUILayout.IntField("Year", data.gameYear);
        data.gamePicture = (Texture)EditorGUILayout.ObjectField("Picture", data.gamePicture, typeof(Texture), false);
        EditorGUILayout.LabelField("Info");
        data.gameInfo = EditorGUILayout.TextArea(data.gameInfo);
    }
}
