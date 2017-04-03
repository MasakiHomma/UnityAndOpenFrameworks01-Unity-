using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]

public class SphereScript_00 : MonoBehaviour {
	private float volume;
	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent <AudioSource> ();
		InitRecord ();
	}

	void Update () {
		volume = GetAverageVolume ();
		Vector3 vec3 = new Vector3 ();
		vec3 = this.transform.position;
		vec3 = new Vector3 (0, volume, 0);
		this.transform.position = vec3;
	}

	void InitRecord () {
		audioSource.clip = Microphone.Start (Microphone.devices[0],true,1,44100);
		//Microphone.Start (デバイス名,lengthSec に到達したときにクリップの最初に戻って録音を継続する,録音するオーディオクリップの長さ,録音するオーディオクリップの周波数)
		audioSource.loop = true; //audioSource.clipをループさせるか
		audioSource.mute = false;
		while(!(Microphone.GetPosition("") > 0)){} //録音が開始されるまで待つ
		audioSource.Play();
	}

	float GetAverageVolume () {
		float[] date = new float[256];
		float sum = 0;
		audioSource.GetOutputData (date,0);
		foreach (float i in date) {
			sum += Mathf.Abs (i);
		}
		sum /= 256.0f; //256個のデータの平均
		return sum * 100;//データの値を大きくして返す
	}
}
