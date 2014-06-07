using UnityEngine;
using System.Collections;

public class movEstrella : MonoBehaviour {

	static public Vector3 tamaño;
	static public bool borrar;
	private bool once;
	private float velocidadGiro;
	private bool cuenta;
	// Use this for initialization
	void Start () 
	{
		once = true;
		borrar = false;
		velocidadGiro = aparecerEstrellas.velocidadGiro;
		cuenta = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (MoverUfo.xUfo>transform.position.x && cuenta==true)
		{
			if (aparecerEstrellas.velocidadMov<6.2f)
			{
				if (aparecerEstrellas.velocidadGiro < 0)
				{
					aparecerEstrellas.velocidadGiro--;
				}
				else if (aparecerEstrellas.velocidadGiro > 0)
				{
					aparecerEstrellas.velocidadGiro++;
				}
				aparecerEstrellas.velocidadMov = aparecerEstrellas.velocidadMov+0.25f;
			}
			Score.contador++;
			cuenta=false;
		}

		if (aparecerEstrellas.choque==false)
		{
			tamaño=renderer.bounds.size; 

			transform.Rotate (0,0,velocidadGiro*Time.deltaTime); // rota el objeto los grados especificados por segundo

			Vector3 inicial = transform.position;
			Vector3 final = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

			final.x = 0 - tamaño.x-1.70f;
			final.y = inicial.y;
			Vector3 direccion = final - inicial;
			direccion.z = 0;
			direccion.Normalize();
			direccion = (direccion * aparecerEstrellas.velocidadMov) + inicial;
			transform.position = Vector3.Lerp (inicial, direccion, Time.deltaTime);

			if (transform.position.x <= 0&& once ==true) 
			{
				aparecerEstrellas.conteo= aparecerEstrellas.conteo-1;
				once=false;
			}

			if (transform.position.x <= (0 - (tamaño.x/2)-0.5)||borrar==true) 
			{
				Destroy (gameObject);

			}
		}
	}
}