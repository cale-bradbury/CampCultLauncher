using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;

public class GamesList : MonoBehaviour {

    public GameObject buttonPrefab;
    GameData[] data;
    public Text namePanel;
    public Text infoPanel;
    public Text yearPanel;
    public CCReflectTexture textureOut;
    int active = 0;
    bool needsFullscreen = false;

    // Use this for initialization
    void OnEnable () {
        data = GameObject.FindObjectsOfType<GameData>();
        for(int i = 0; i<data.Length; i++)
        {
            GameObject g = (GameObject)Instantiate(buttonPrefab);
            g.transform.SetParent(transform) ;
            g.transform.localScale = Vector3.one;
            Button b = g.GetComponent<Button>();
            int j = i;
            b.onClick.AddListener(delegate { UpdateData(j); });
            b.GetComponentInChildren<Text>().text = data[i].gameName;
        }
        UpdateData(0);
	}

    void Update()
    {
        if (needsFullscreen)
        {
            needsFullscreen = false;
            Screen.fullScreen = true;
        }

    }
	
	void UpdateData (int i)
    {
        active = i;
        GameData d = data[i];
        namePanel.text = d.gameName;
        infoPanel.text = d.gameInfo;
        yearPanel.text = ""+d.gameYear;
        //textureOut.SetValue(d.gamePicture);
    }

    public void Play()
    {
        Process p = Process.Start(data[active].gamePath);
        p.EnableRaisingEvents = true;
        p.Exited += Restore;
    }

    void Restore(object from, System.EventArgs args)
    {
        UnityEngine.Debug.Log("back");
        needsFullscreen = true;
    }
}
