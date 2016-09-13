using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public Vector3 pos;
	private GameObject player, bullets;

	Vector2 target, myPos, direction;
	// Use this for initialization
	void Start () {
		//mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		//Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		player = GameObject.Find ("Player");
		target = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		myPos = new Vector2(transform.position.x,transform.position.y);
		direction = target - myPos;
		direction.Normalize();

		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = direction*speed;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i =0; i<enemies.Length; i++) {
			if ((enemies[i].GetComponent<Enemy>().isDead())){
				Physics2D.IgnoreCollision (enemies[i].GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			}
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log (col.gameObject.name);
		if ((!(col.gameObject.name.StartsWith("projectile")))&& (!col.gameObject.name.StartsWith("Player"))&&(!col.gameObject.name.StartsWith("Pellet")))
		{

			Destroy (gameObject);
		}
	}
}
