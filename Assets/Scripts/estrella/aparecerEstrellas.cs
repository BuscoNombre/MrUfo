using UnityEngine;
using System.Collections;

public class aparecerEstrellas : MonoBehaviour {

	public GameObject estrella;
	public GameObject reintentar;

	static public int velocidadGiro;
	static public float velocidadMov;
	static public float conteo;
	static public float aceptadas;
	static public bool choque;
	static public bool once;

	private float segmento;
	static public bool direccionGiro;

	// Use this for initialization
	void Start () {
		velocidadGiro = -70;
		velocidadMov = 3f;
		aceptadas = 2f;
		conteo = 0f;
		choque = false;
		once = true;
		direccionGiro = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 limites = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		if (choque==false)
		{

			if (conteo==0) 
			{
				if (direccionGiro==true && velocidadGiro< 0)
				{
					velocidadGiro= velocidadGiro * (-1);
					direccionGiro=false;
				}
				else if (direccionGiro == false && velocidadGiro >0)
				{
					velocidadGiro = velocidadGiro * (-1);
					direccionGiro=true;
				}

				Vector3 inicio= new Vector3 (0f,0f,0f);
				inicio.x= limites.x + 1.35f ;
				inicio.y= Random.Range (0.8f, limites.y-0.8f);
				Instantiate (estrella, inicio,Quaternion.identity);
				conteo ++;
			}
			else if (conteo>0)
			{
				if (conteo<aceptadas && PedirEstrella.peticion==true)
				{
					if (direccionGiro==true && velocidadGiro< 0)
					{
						velocidadGiro= velocidadGiro * (-1);
						direccionGiro=false;
					}
					else if (direccionGiro == false && velocidadGiro >0)
					{
						velocidadGiro = velocidadGiro * (-1);
						direccionGiro=true;
					}
					Vector3 inicio= new Vector3 (0f,0f,0f);
					inicio.x= limites.x + 1.35f ;
					inicio.y= Random.Range (0.8f, limites.y-0.8f);
					Instantiate (estrella, inicio,Quaternion.identity);
					conteo ++;

				}
			}
		}
		else if (choque==true && once==true)
		{
			Vector3 inicio= new Vector3 (0f,0f,0f);
			inicio.x = limites.x /2;
			inicio.y = limites.y /2;
			Instantiate (reintentar, inicio, Quaternion.identity);
			once=false;
		}

	}
}
