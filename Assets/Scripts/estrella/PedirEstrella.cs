using UnityEngine;
using System.Collections;

public class PedirEstrella : MonoBehaviour {

	static public bool peticion;

	float conteoSegmentos;
	float segmento;
	// Use this for initialization
	void Start () 
	{
		peticion = false;
		conteoSegmentos = 1;
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 limites = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		segmento= ((aparecerEstrellas.aceptadas-conteoSegmentos)/aparecerEstrellas.aceptadas) * (limites.x+ 1.35f);
		if (segmento !=0 && transform.position.x <= segmento)
		{
			peticion=true;
			conteoSegmentos++;
		}
	}
}
