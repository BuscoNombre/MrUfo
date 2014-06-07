using UnityEngine;
using System.Collections;

public class ufoTriggerAnimations : MonoBehaviour 
{

	private Animator animador;
	private MoverUfo movScript;
	private ufoTriggerAnimations animScript;
	private sacarDeCuadro sacar1;
	private sacarDeCuadro sacar2;
	private SacarDeCuadro2 sacar3;

	public GameObject Ufo;
	public GameObject Titulo;
	public GameObject Instruccion;
	public GameObject EstrellaIntro;

	private float sonrie;

	void Awake ()
	{
		animador = GetComponent <Animator> ();
		movScript = Ufo.GetComponent <MoverUfo> ();
		animScript = GetComponent <ufoTriggerAnimations> ();
		sacar1 = Titulo.GetComponent <sacarDeCuadro> ();
		sacar2 = Instruccion.GetComponent <sacarDeCuadro> ();
		sacar3 = EstrellaIntro.GetComponent <SacarDeCuadro2> ();

	}
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			animador.SetBool ("avanzando", true);
		}

		if (Input.GetButtonUp ("Fire1"))
		{
			animador.SetBool ("avanzando", false);
		}

		bool entrando = animador.GetBool ("entrando");
		bool avanzando = animador.GetBool ("avanzando");
		bool impactado = animador.GetBool ("impactado");

		if (entrando == false && avanzando == false && impactado == false) 
		{
			sonrie += Time.deltaTime;
			if (sonrie>=3 && sonrie<4)
			{
				animador.SetBool ("sonriendo", true);
			}

			else if (sonrie>=4)
			{
				sonrie=0;
				animador.SetBool ("sonriendo", false);
			}
		}

		else 
		{
			sonrie=0;
			animador.SetBool ("sonriendo", false);
		}
	}

	public void FinalizarIntro ()
	{
		animador.SetBool ("entrando", false);
		movScript.enabled = true;
		animScript.enabled = true;
		sacar1.enabled = true;
		sacar2.enabled = true;
		sacar3.enabled = true;
		Sonidos.animTerm = true;

	}

}
