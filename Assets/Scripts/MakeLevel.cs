using UnityEngine;
using System.Collections;
using System;



public class MakeLevel : MonoBehaviour {


	GameObject [] enemies;
	bool making = true;

	public int maxFloorSize=20;
	public GameObject tile, wall, enemy;
	public GameObject exit;

	private GameObject player;
	ArrayList grid = new ArrayList();

	int x=0,y=0,current =1;
	bool madeExit = false;
	ArrayList farEnough = new ArrayList();

	// Use this for initialization
	void Start () {
		//set up first floor tile
		Instantiate (tile, new Vector3 (x, y, 1), Quaternion.identity);

		//add to list of floor tiles you've been too
		grid.Add (new Vector3(x,y,1));

		while (making)
		{
			if (current == maxFloorSize)
			{
				break;
			}
			float rng = UnityEngine.Random.value;
			if (rng<0.25)
			{
				x++;
			}
			else if ((rng>=0.25)&&(rng<0.5))
			{
				x--;
			}
			else if ((rng>=0.5)&&(rng<0.75))
			{
				y++;
			}
			else if ((rng>=0.75)&&(rng<=1))
			{
				y--;
			}
			Vector3 pos = new Vector3(x,y,1);

			if (!grid.Contains(pos))
			{
				if (Vector3.Distance(pos, (Vector3)grid[0])> 10){
					farEnough.Add (pos);
				}
				Instantiate(tile, new Vector3(x,y,1), Quaternion.identity);
				grid.Add (new Vector3(x,y,1));

				current++;
			}
		}

		//making walls
		for (int i =0; i<grid.Count;i++)
		{
			Vector3 V = (Vector3)grid[i];
			Vector3 blockCheck = V;

			blockCheck.x++;

			addWall(blockCheck);
			if (!(inArrayList(blockCheck)))
			{

				Instantiate(wall, blockCheck, Quaternion.identity);

			}

			blockCheck.x-=2;
			addWall(blockCheck);

			blockCheck.x +=1;
			blockCheck.y++;
			addWall(blockCheck);


			blockCheck.y-=2;
			addWall(blockCheck);
		}
		player = GameObject.Find ("Player");
		Vector3 newPos = (Vector3)grid [0];
		newPos.z = player.transform.position.z;
		player.transform.position = newPos;

		addEnemies ();

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}

	void addEnemies()
	{
		System.Random number = new System.Random();
		int amount = (maxFloorSize %5)+8;
		Debug.Log (farEnough.Count);
		for (int i =0; i < amount; i++) {
			int location = number.Next (farEnough.Count);
//			while (location>farEnough.Count){
//				location = number.Next ();
//			}
		
			Vector3 enemyLocation = (Vector3)farEnough [location];
			enemyLocation.z = 0;
			Instantiate (enemy, enemyLocation, Quaternion.identity);
		}

	}

	void addWall(Vector3 wallCheck)
	{
		for (int m =0;m<grid.Count;m++)
		{
			Vector3 check = (Vector3)grid[m];

			if (check == wallCheck)
			{
				return;
			}
		}
		Instantiate(wall, wallCheck, Quaternion.identity);
	}

	bool inArrayList(Vector3 V)
	{
		for (int i =0; i<grid.Count; i++) {

			Vector3 check = (Vector3) grid[i];

			//Debug.Log(check);
			if (check == V)
			{
				return true;
			}
		}
		return false;
	}
	// Update is called once per frame
	void Update () {

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		if ((enemies.Length==0)&&(madeExit==false)){
			if (!madeExit){
				Instantiate(exit, (Vector3)grid[grid.Count-3], Quaternion.identity);
				madeExit=true;
			}
			
		}
		
	}
}
