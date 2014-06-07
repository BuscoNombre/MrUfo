using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int contador;

	// Use this for initialization
	void Start () 
	{
		contador = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		guiText.text = "Score=" + contador;
	
	}
}
