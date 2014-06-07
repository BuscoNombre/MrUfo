using UnityEngine;
using System.Collections;

public class SacarDeCuadro2 : MonoBehaviour {
	
	private Animator animador;
	private bool primerClick;
	private aparecerEstrellas spawn;
	
	public GameObject SpawnerEstrellas;
	public GameObject Score;
	public GameObject HiScore;
	
	void Awake ()
	{
		animador = GetComponent <Animator> ();
		spawn = SpawnerEstrellas.GetComponent <aparecerEstrellas> ();
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

	void DesactivarAnimatorYActivarEstrellas ()
	{
		animador.enabled = false;
		spawn.enabled = true;

		Vector3 inicio = new Vector3 (0.14f, 0.94f, 0f);
		Instantiate (Score, inicio,Quaternion.identity);

		Vector3 inicioHi = new Vector3 (0.50f, 0.94f, 0f);
		Instantiate (HiScore, inicioHi, Quaternion.identity);

		Destroy (gameObject);
	}
}

