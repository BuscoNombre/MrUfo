using UnityEngine;
using System.Collections;

public class HiScore : MonoBehaviour {

	public static int hiScore;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		hiScore=PlayerPrefs.GetInt ("hiscore");
		if (Score.contador > hiScore) 
		{
			hiScore=Score.contador;
			PlayerPrefs.SetInt ("hiscore", hiScore);
		}
		guiText.text = "Hi-Score=" + hiScore;
	}
}
