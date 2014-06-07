using UnityEngine;
using System.Collections;

public class Sonidos : MonoBehaviour {

	private bool primerClick;
	private bool primerCambio;
	private bool hecho;
	private bool once;

	public AudioSource inicio;
	public AudioSource entrada;
	public AudioSource choque;
	public AudioClip epica;
	public AudioClip intensa;

	public static bool reiniciando;
	public static bool silenciado;
	public static bool animTerm;
	public static bool choco;

	// Use this for initialization
	void Start () 
	{
		primerClick = true;
		primerCambio = true;
		reiniciando = false;
		silenciado = false;
		animTerm = false;
		hecho = false;
		choco = false;
		once = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Slenciar
		if (silenciado==true && hecho ==false) 
		{
			inicio.Pause();
			if (animTerm == false)// si la animacion no a temrinado silencia el audio entrada que estara destruido para cuando termine la anim
			{
				entrada.mute=true;
			}
			hecho=true; // con esto se silenciara un vez para evitar instrucciones innecesarias
		}
		else if (silenciado==false && hecho==true)
		{
			inicio.Play();
			if (animTerm ==false)
			{
				entrada.mute =false;
			}
			hecho=false;
		}
		//destruir entrada cuando la animacion termina
		if (animTerm ==true)
		{
			Destroy (entrada);
		}
		//cambiar clip cuando se inicia el juego
		if (Input.GetButtonDown ("Fire1") && primerClick == true && animTerm==true) 
		{
			inicio.clip=epica;
			if (silenciado==false)
			{
				inicio.Play ();
			}
			primerClick=false;
		}
		//cambiar clip cuando se lleva a 30 pero 28 para compensar el tiempo en el q cambia la cancion
		if (Score.contador > 28 && primerCambio == true) 
		{
			inicio.clip=intensa;
			if (silenciado==false)
			{
				inicio.Play ();
			}
			primerCambio=false;
		}
		//reinicia a clip epico cuando se esta tocando otro clip
		if (reiniciando == true) 
		{
			inicio.clip =epica;
			if (silenciado==false)
			{
				inicio.Stop ();
				inicio.Play ();
			}
			primerCambio=true;
			reiniciando=false;
			choco=false;
			once=true;
			choque.enabled=false;
		}
		//si choca pausa la musica y habilita el sonido del choque
		if (choco == true && once == true) 
		{
			if (silenciado==false)
			{
				inicio.Pause ();
				choque.enabled=true;

			}
			once=false;
		}
    }
}