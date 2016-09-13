using UnityEngine;
using System.Collections;

public class ShotgunBurst : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (RemoveProjectile());
		GameObject player = GameObject.Find ("Player");
		Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<PolygonCollider2D>());
		//Debug.Log (Physics2D.GetIgnoreCollision (player.GetComponent<Collider> (), GetComponent<Collider> ()));
	}

	IEnumerator RemoveProjectile()
	{

		yield return new WaitForSeconds(0.3f);

		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
