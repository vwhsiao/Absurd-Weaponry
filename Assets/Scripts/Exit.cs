using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		sprite.sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//	void OnCollisionEnter2D(Collision2D col)
//	{
//		Debug.Log (col.gameObject.name);
//	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.StartsWith ("Player")) {
			Application.LoadLevel("Level");
		}
	}

}
