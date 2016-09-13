using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Vector2 dir;
	public Transform firePoint;
	public GameObject projectile;
	public GameObject shotgun;
	public float MoveSpeed;
	GameObject player;

	public bool dead = false;
	Vector2 myPos, target, direction;




	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		InvokeRepeating ("Fire", 3, 2);

		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i =0; i<enemies.Length; i++) {
			Physics2D.IgnoreCollision (enemies[i].GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		if (dead) {

		//	float distance = Vector3.Distance(GetComponent<Rigidbody2D> ().velocity, Vector3.zero);
		//	GetComponent<Rigidbody2D> ().velocity = Vector3.Lerp(GetComponent<Rigidbody2D> ().velocity,-GetComponent<Rigidbody2D> ().velocity,distance) ;

		} else {
			transform.rotation = Quaternion.LookRotation (Vector3.forward, player.transform.position - transform.position);
		}
	}

	void Fire()
	{
		Instantiate (projectile, firePoint.position, firePoint.rotation);

	}
	

	public bool isDead()
	{
		return (dead==true);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name.StartsWith("projectile")||(col.gameObject.name.StartsWith("Shotgun")))
		{
			Instantiate (shotgun, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}


		//if (col.gameObject.name.StartsWith ("blocking")) {
		//	GetComponent<Rigidbody2D> ().velocity = -GetComponent<Rigidbody2D> ().velocity;
		//}
	}

}
