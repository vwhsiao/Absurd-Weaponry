using UnityEngine;
using System.Collections;

public class EnemyProjectiles : MonoBehaviour {
	public float speed;
	public Vector3 pos;
	private GameObject player, bullets, triangle;
	//public string enemyName;
	Vector2 myPos, direction, target;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

		myPos = new Vector2(transform.position.x,transform.position.y);
		target = player.transform.position;
		direction = target - myPos;
		direction.Normalize();
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i =0; i<enemies.Length; i++) {
			Physics2D.IgnoreCollision (enemies[i].GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = direction*speed;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{


		if (!(col.gameObject.name.StartsWith("projectile"))&&(!(col.gameObject.name.StartsWith("Triangle"))))
		{
			
			Destroy (gameObject);
		}
	}

}
