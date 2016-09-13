using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	public Transform firePoint;
	public GameObject projectile,shotgunBurst;
	int clicks;
//	public GameObject healthBar;

	Vector2 dir;
	public float MoveSpeed;
	ArrayList guns = new ArrayList();

	int bullets=0,shells=0;
	int health = 7, equippedIndex = 0;
	private static Text HP;
    
	private string equippedGun;
	public static Character control;

	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (this);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
		HP=GameObject.Find ("HP").GetComponent<Text> ();


	}

	void Start()
	{
		guns.Add ("Pistol");
		equippedGun = (string)guns [0];


	}

	public void AddWeapon(string gun)
	{
		if (guns.Contains (gun) != true) {
			guns.Add(gun);
		}
	}

	void FixedUpdate()
	{
		HP.text = "HP: " + health.ToString();
        
	}

	// Update is called once per frame
	void Update () {


		//rotating character to follow mouse
//		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		//move character code
		if (Input.GetKey (KeyCode.W) && (Input.GetKey (KeyCode.A))) { //top left
			dir = Vector2.up;
			dir+=-Vector2.right;
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;
		}

		else if (Input.GetKey (KeyCode.W) && (Input.GetKey (KeyCode.D))) { //top right
			dir = Vector2.up;
			dir+=Vector2.right;
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;
		}

		else if (Input.GetKey (KeyCode.S) && (Input.GetKey (KeyCode.D))) { //bottom right
			dir = -Vector2.up;
			dir+=Vector2.right;

			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;
		}
		else if (Input.GetKey (KeyCode.S) && (Input.GetKey (KeyCode.A))) { //bottom right
			dir = -Vector2.up;
			dir+=-Vector2.right;
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;
		}

		else if (Input.GetKey (KeyCode.D)) {

			dir = Vector2.right;
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;

		} else if (Input.GetKey (KeyCode.S)) {

			dir = -Vector2.up;    // '-up' means 'down'
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;

		} else if (Input.GetKey (KeyCode.A)) {

			dir = -Vector2.right; // '-right' means 'left'
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;

		} else if (Input.GetKey (KeyCode.W)) {

			dir = Vector2.up;
			GetComponent<Rigidbody2D> ().velocity = dir*MoveSpeed;

		} 
		else {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			int maxIndex = guns.Count-1;
			if (equippedIndex!=maxIndex)
			{
				equippedIndex++;

			}
			else{
				equippedIndex = 0;

			}
			equippedGun = (string)guns[equippedIndex];
		}


		//firing weapons
		if (Input.GetMouseButtonDown (0)) {
			clicks++;
			Debug.Log(clicks);
			clicks--;
			if (equippedGun == "Pistol"){
				clicks++;
				Debug.Log(clicks);
				Instantiate(projectile, firePoint.position, firePoint.rotation);
			}
			else if (equippedGun.StartsWith("Shotgun"))
			{

				Instantiate(shotgunBurst, firePoint.position, firePoint.rotation);
				Instantiate(shotgunBurst, firePoint.position,firePoint.rotation);
			}
		}


	}
	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "EnemyProjectile") {
			health--;
		}
		//if ((!(col.gameObject.name.StartsWith(
	}
}
