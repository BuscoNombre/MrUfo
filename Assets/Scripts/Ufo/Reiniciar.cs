using UnityEngine;
using System.Collections;

public class Reiniciar : MonoBehaviour {

	public GameObject Ufo;

	private MoverUfo movUfo;
	private Animator animador;

	public static bool reinicia;

	void Awake ()
	{
		movUfo= GetComponent <MoverUfo>();
		animador = Ufo.GetComponent <Animator> ();
	}
	
	// Use this for initialization
	void Start () 
	{
		reinicia = false;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (reinicia == true) 
		{
			Vector3 inicio = new Vector3 (1.74667f,1.419995f,0f);
			transform.position= inicio;

			aparecerEstrellas.choque=false;
			aparecerEstrellas.once=true;
			movEstrella.borrar=true;
			aparecerEstrellas.conteo=0;
			aparecerEstrellas.velocidadGiro=-60;
			aparecerEstrellas.velocidadMov=3f;
			aparecerEstrellas.direccionGiro=true;

			Score.contador=0;

			movUfo.enabled=true;
			animador.SetBool ("impactado", false);

			Sonidos.reiniciando=true;

			reinicia=false;
		}
	}
}
