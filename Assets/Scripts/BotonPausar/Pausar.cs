﻿using UnityEngine;
using System.Collections;

public class Pausar : MonoBehaviour {

	private Vector3 posicion;
	private Vector3 tamaño;
	private Vector3 toque;
	private Vector3 limSup;
	private Vector3 limInf;
	private bool pausado;
	private SpriteRenderer renderer1;

	public Sprite[] botones;
	
	// Use this for initialization
	void Awake ()
	{
		renderer1 = GetComponent <SpriteRenderer> ();
	}

	void Start () 
	{
		pausado = false;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		posicion = transform.position;
		tamaño = renderer.bounds.size;
		toque = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		limSup= new Vector3(posicion.x+(tamaño.x/2),(posicion.y+ (tamaño.y/2)), 0);
		limInf= new Vector3(posicion.x-(tamaño.x/2),(posicion.y- (tamaño.y/2)), 0);
		if (Input.GetButtonDown ("Fire1")&&((toque.x > limInf.x && toque.x < limSup.x)&& (toque.y > limInf.y && toque.y < limSup.y)))
		{
			if (pausado==false)
			{
				renderer1.sprite=botones [1];
				Time.timeScale=0;
				pausado=true;
			}
			else if (pausado==true)
			{
				renderer1.sprite=botones [0];
				Time.timeScale=1;
				pausado=false;
			}
		}
	
	}
}
