using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centro : MonoBehaviour {

	public Sprite color_1;
	public Sprite color_2;
	public Sprite color_3;
	public Sprite color_4;

	private float vel = 1.0f;			// Velocidad de rotación

	void Update () {
		rotar ();

		// Colores
		if(Menu_index.vida == 10)
			gameObject.GetComponent<SpriteRenderer>().sprite = color_1;	// Azul
		if(Menu_index.vida < 10 && Menu_index.vida >=6)
			gameObject.GetComponent<SpriteRenderer>().sprite = color_2;	// Verde
		if(Menu_index.vida < 6 && Menu_index.vida >=4)
			gameObject.GetComponent<SpriteRenderer>().sprite = color_3;	// Amarillo
		if(Menu_index.vida < 2)
			gameObject.GetComponent<SpriteRenderer>().sprite = color_4;	// Rojo
	}

	void rotar()
	{
		if (Time.timeScale == 1.0f)		// Si esta pausado
			if (Espada.direccion)
				transform.RotateAround (gameObject.transform.position, gameObject.transform.position, vel);
			else
				transform.RotateAround (gameObject.transform.position, gameObject.transform.position, -vel);
	}
}
