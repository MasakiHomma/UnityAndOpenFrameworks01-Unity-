using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SphereScript_01 : MonoBehaviour {
	GameObject target;

	void Start () {
		target = GameObject.Find ("Sphere0");
	}
	
	void Update () {
		Vector3 vec3 = new Vector3 ();
		vec3 = this.transform.position;
		vec3.y = target.transform.position.y * Mathf.Cos (vec3.x * Mathf.PI / 18);
		vec3.y *= -1;
		this.transform.position = vec3;
	}
}
