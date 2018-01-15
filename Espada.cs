using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour {

	public static bool direccion = true;	// false = Manillas del reloj

	private GameObject centro;				// El gameObject "Centro"
	private float tfloat;					// Float temporizador de la mantención

	private float tempo;					// Temporizador de rapidez
	private float tempo_pred = 1.5f;		// Temporizador predeterminado

	private float vel;						// Velocidad de la espada
	private float vel_pred = 3.3f;			// Velocidad predeterminada
	private float vel_doble = 6.8f;			// Velocidad rápida

	void Start () {
		centro = GameObject.Find ("Centro");
		vel = vel_pred;
		tempo = tempo_pred;
		tfloat = 0f;
	}

	void Update () {
		rotar ();

		if (Input.GetButtonDown ("Tap")) {
			tfloat = Time.time;
		}

		if (Input.GetButton ("Tap") && (Time.time - tfloat) > 0.4f) {
			acelerar();
		}
		else if (Input.GetButtonUp ("Tap") && (Time.time - tfloat) < 0.4f) {
			clic_simple();
		}

		if (Input.GetButtonUp("Tap")) {
			tempo = tempo_pred;
			desactivar ();
		}
	}

	void clic_simple()
	{
		if (direccion)
			direccion = false;
		else
			direccion = true;
	}

	void acelerar()
	{
		vel = vel_doble;
		tempo -= Time.deltaTime;
		if (tempo <= 0.0f)
			desactivar();
	}

	void desactivar()
	{
		vel = vel_pred;
	}

	void rotar()
	{
		if (Time.timeScale == 1.0f)  // Si esta pausado
			if(direccion)
				transform.RotateAround (centro.transform.position, centro.transform.position, -vel);
			else
				transform.RotateAround (centro.transform.position, centro.transform.position, vel);
	}
}
