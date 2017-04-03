using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SphereMaterialScript : MonoBehaviour {
	OSCControl oscControl;
	Renderer rend;

	void Start () {
		oscControl = GameObject.Find ("Directional Light").GetComponent <OSCControl> ();
		rend = this.gameObject.GetComponent <Renderer> ();
	}
	
	void Update () {
		if (oscControl.message == "red") {
			rend.material.color = new Color (255, 0, 0);
		} else if (oscControl.message == "green") {
			rend.material.color = new Color (0, 255, 0);
		} else if (oscControl.message == "blue") {
			rend.material.color = new Color (0, 0, 255);
		} else {
			rend.material.color = new Color (0, 0, 0);
		}
	}
}
