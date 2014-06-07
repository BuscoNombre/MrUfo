using UnityEngine;
using System.Collections;

public class sacarDeCuadro : MonoBehaviour {

	private Animator animador;
	private bool primerClick;
	private aparecerEstrellas spawn;

	void Awake ()
	{
		animador = GetComponent <Animator> ();
	}

	// Use this for initialization
	void Start () 
	{
		primerClick = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && primerClick == false) 
		{
			animador.SetBool ("desvaneciendo", true);
			primerClick = true;
		}
	}

	void DescativarAnimator ()
	{
		animador.enabled = false;
		Destroy (gameObject);
	}

}
