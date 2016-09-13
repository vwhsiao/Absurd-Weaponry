using UnityEngine;
using System.Collections;

public class WeaponRotate : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		 player= GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		Quaternion x = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
//		Debug.Log ("transform.rotation: " + transform.rotation);
//		Debug.Log ("x: " + x);
//		Debug.Log (Quaternion.Angle ( transform.rotation,x));
//		transform.RotateAround (player.transform.position, new Vector3(0,0,1),Quaternion.Angle(x, transform.rotation));
//
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}
}
