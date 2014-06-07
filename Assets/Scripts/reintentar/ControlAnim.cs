using UnityEngine;
using System.Collections;

public class ControlAnim : MonoBehaviour {

	private Animator animador;
	private bool finAnim;

	void Awake ()
	{
		animador= GetComponent <Animator> ();
	}

	// Use this for initialization
	void Start () 
	{
		finAnim = false;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (finAnim ==true && Input.GetButtonDown ("Fire1"))
		{
			animador.SetBool ("desapareciendo", true);
		}
	}

	void Desvanece ()
	{
		finAnim = true;
	}

	void Destruye ()
	{
		Reiniciar.reinicia = true;
		Destroy (gameObject);
	}
}
