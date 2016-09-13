using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public void LoadThisLevel(int level)
	{
		Application.LoadLevel(level);
	}
	public void Quit()
	{
		Application.Quit ();
	}
}
