using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_index : MonoBehaviour {

	public static int vida;					// Vida del juego
	public static int puntaje;				// Puntaje del juego
	public static int puntaje_max;			// Máximo puntaje logrado

	public GameObject bolita;
	public GameObject reload;
	public GameObject espada;
	public GameObject centro;
	public GameObject hud;
	public GameObject menu_muerte;
	public GameObject menu_pausa;
	public Text txt_btn_puntaje;
	public Text txt_puntaje;
	public Text txt_puntaje_max;
	public Text txt_puntaje_pausa;
	public Camera camara;

	public AudioSource fuente;
	public AudioClip sonido_fin;

	private float tempo;					// Tiempo de aparición entre una bolita y otra
	private float tempo_pred = 0.6f;		// Tiempo de aparición predeterminado
	private bool menu = true;
	private bool pausado;

	void Start () {
		Time.timeScale = 1.0f;
		pausado = false;

		vida = 10;
		puntaje = 0;

		hud.SetActive (true);
		menu_muerte.SetActive (false);
		menu_pausa.SetActive (false);

		// Cargar puntaje
		//puntaje_max = Save_load.load_puntaje(); 
	}

	void Update () {
		// Puntaje
		txt_puntaje.text = puntaje.ToString();
		txt_puntaje_pausa.text = puntaje.ToString ();

		if (vida > 0) {
			// Iniciación de las bolitas
			tempo -= Time.deltaTime;
			if (tempo <= 0.0f) {
				tempo = tempo_pred;
				GameObject b = Instantiate (bolita);

				float izquierda_iniciacion_x = Random.Range(-20, -20);
				float izquierda_iniciacion_y = Random.Range(20, -20);

				float derecha_iniciacion_x = Random.Range(20, 20);
				float derecha_iniciacion_y = Random.Range(20, -20);

				float arriba_iniciacion_x = Random.Range(-20, 20);
				float arriba_iniciacion_y = Random.Range(20, 20);

				float abajo_iniciacion_x = Random.Range(-20, 20);
				float abajo_iniciacion_y = Random.Range(-20, -20);

				float aleatorio = Random.Range(0, 4);
				if(aleatorio == 0)
					b.transform.position = new Vector2 (izquierda_iniciacion_x, izquierda_iniciacion_y);
				if(aleatorio == 1)
					b.transform.position = new Vector2 (derecha_iniciacion_x, derecha_iniciacion_y);
				if(aleatorio == 2)
					b.transform.position = new Vector2 (arriba_iniciacion_x, arriba_iniciacion_y);
				if(aleatorio == 3)
					b.transform.position = new Vector2 (abajo_iniciacion_x, abajo_iniciacion_y);
			}
		}
		if (vida <= 0)
			if(menu)
				cancelar_partida ();

		// Salir de la partida
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (pausado)
				volver ();
			else if (vida <= 0)
				volver ();
			else
				pausar ();
		}

		// Tamaño por orientación
		if (Input.deviceOrientation == DeviceOrientation.Portrait) {
			camara.orthographicSize = 9;
		} 
		else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
			camara.orthographicSize = 9;
		}

	}

	void cancelar_partida()
	{
		menu = false;
		fuente.PlayOneShot (sonido_fin);
		hud.SetActive (false);
		menu_muerte.SetActive (true);
		Destroy(espada);
		Destroy(centro);
		GameObject[] clones = GameObject.FindGameObjectsWithTag("Bolita_tag");
		foreach(GameObject b in clones)
			Destroy(b);
		
		calcular_puntaje ();
	}

	void calcular_puntaje()
	{
		if (puntaje > puntaje_max) {
			puntaje_max = puntaje;

			// Guardar partida
			//Save_load.save(puntaje_max);
		}

		txt_btn_puntaje.text = puntaje.ToString ();
		txt_puntaje_max.text = puntaje_max.ToString ();
	}

	public void reiniciar()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void volver()
	{
		calcular_puntaje ();
		SceneManager.LoadScene ("Menu");
	}

	void pausar()
	{
		pausado = true;
		hud.SetActive (false);
		menu_pausa.SetActive (true);
		Time.timeScale = 0.0f;
	}

	public void des_pausar()
	{
		pausado = false;
		hud.SetActive (true);
		menu_pausa.SetActive (false);
		Time.timeScale = 1.0f;
	}
}
