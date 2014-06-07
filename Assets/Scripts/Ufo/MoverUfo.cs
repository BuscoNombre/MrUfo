using UnityEngine;
using System.Collections;

public class MoverUfo : MonoBehaviour {

	public static float xUfo;

	public float velocidad ;

	private bool reversa;
	private bool presAntes;
	
	// Use this for initialization
	void Start () 
	{
		velocidad = 7.5f;
		presAntes = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		xUfo = transform.position.x;
		if (Input.GetButtonDown ("Fire1"))
		{
			presAntes=false;
		}

		if (Input.GetButton ("Fire1") && presAntes == false)  // si se presiona mouse0
		{

			Vector3 posicionDelUfo = transform.position; //Nuevo vector que sera igual a la posicion actual del objeto
			Vector3 posicionDelRaton = Camera.main.ScreenToWorldPoint( Input.mousePosition ); // Convierte la posicion del raton a cordenadas dentro del juego
			Vector3 limites = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0)); // consigue el tamaño de la pantalla
			Vector3 tamaño =renderer.bounds.size; //obtiene el tamaño del objeto
			posicionDelRaton.x = Mathf.Clamp (posicionDelRaton.x,  0, limites.x- (tamaño.x/4));//limita 
			posicionDelRaton.y = Mathf.Clamp (posicionDelRaton.y, 0, limites.y- (tamaño.y/4));
			Vector3 direccion = posicionDelRaton - posicionDelUfo;
			if (direccion.magnitude>=10.001)
			{
				direccion.z = 0;
				direccion.Normalize();// si no se normaliza la velocidad variara dependiendo de q tan lejos del objeto se de el click
				direccion = direccion * velocidad +posicionDelUfo;
				transform.position = Vector3.Lerp( posicionDelUfo, direccion, Time.deltaTime );

				//arreglar reversa

				if (direccion.x<transform.position.x && reversa == false)
				{
					Vector3 escalar= transform.localScale;
					escalar.x= escalar.x*-1;
					transform.localScale=escalar;
					reversa= true;
				}
				if (direccion.x >= transform.position.x && reversa == true)
				{
					Vector3 escalaf= transform.localScale;
					escalaf.x= escalaf.x*-1;
					transform.localScale=escalaf;
					reversa=false;
				}

			}
		}
		
	}
}
