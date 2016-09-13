using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

	Vector3 pos;
	double Damping = 5.0;
	Transform Player;
	int Height = 4;
	int Offset = 5;
	public float CameraNormalizeAmount=4;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player").GetComponent<Transform>();
		transform.position = Player.transform.position;
		Cursor.lockState = CursorLockMode.Confined;
	}
	

	
	private Vector3 Center;
	double ViewDistance = 5.0;
	
	void FixedUpdate () 
	{

		Center = Player.transform.position;
		Center.z = -2;
		transform.position = Center;

		Vector3 mousePos = Input.mousePosition;    
		mousePos.z = (float)ViewDistance; 
		Vector3 CursorPosition= Camera.main.ScreenToWorldPoint(mousePos); 

		Vector3 PlayerPosition = Player.transform.position; 

//		Debug.Log ("Player: "+PlayerPosition.x+ " "+ PlayerPosition.y);
//		Debug.Log ("Cursor: "+ CursorPosition.x+ " "+ CursorPosition.y);
		Center = new Vector3((transform.position.x + CursorPosition.x) / 2, (transform.position.y+CursorPosition.y)/2, -2); 
		Center.Normalize ();
//		Center = Center *CameraNormalizeAmount;
		Center.z = -2;
		transform.position = Vector3.Lerp(transform.position, (Player.transform.position+Center), (float).3); 

		//Center = Player.transform.position;
//		Center.z = -2;
//		transform.position = Center;



	}

		/*if (Input.GetAxis("Mouse ScrollWheel")>0) // forward
		{
			if (Camera.main.orthographicSize>1){
			Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize-1, 1);
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel")<0) // forward
		{
			Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize+1, 300);
		}*/
		//player.transform.position.y, transform.position.z);
}

