using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name.StartsWith("Player"))
		{
			Debug.Log(gameObject.name);
			player.GetComponent<Character>().AddWeapon(gameObject.name);
			Destroy (gameObject);
		}
	}

}
