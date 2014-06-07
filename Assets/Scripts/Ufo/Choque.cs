using UnityEngine;
using System.Collections;

public class Choque : MonoBehaviour {

	public GameObject Ufo;

	private Animator animador;
	private MoverUfo moverUfo;

	void Awake ()
	{
		animador = GetComponent <Animator> ();
		moverUfo = Ufo.GetComponent <MoverUfo> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		animador.SetBool ("impactado", true);
		moverUfo.enabled = false;
		aparecerEstrellas.choque = true;
		Sonidos.choco = true;
	}
}
