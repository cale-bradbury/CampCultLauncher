using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class Launcher : MonoBehaviour {

    public string path;

	// Use this for initialization
	void Start () {
        Process.Start(path, "-skip-screen-selector");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
