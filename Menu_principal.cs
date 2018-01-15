using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu_principal : MonoBehaviour {

	public static bool mute;

	public Text txt_puntaje_max;
	public GameObject btn_superior;
	public GameObject btn_inferior;
	public GameObject menu_ayuda;
	public Camera camara;

	public Image volumen;
	public Sprite volumen_on;
	public Sprite volumen_off;

	void Start () {
		Time.timeScale = 1.0f;

		// Cargar puntaje
		txt_puntaje_max.text = Menu_index.puntaje_max.ToString();
	}

	void Update()
	{
		btn_superior.transform.RotateAround (btn_superior.transform.position, btn_superior.transform.position, 0.1f);
		btn_inferior.transform.RotateAround (btn_inferior.transform.position, btn_inferior.transform.position, -0.5f);

		//Salir de la aplicación
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void iniciar()
	{
		SceneManager.LoadScene ("Index");
	}

	public void activar_sonido()
	{
		if (mute) {
			AudioListener.pause = false;
			volumen.sprite = volumen_on;
			mute = false;
		} else {
			AudioListener.pause = true;
			volumen.sprite = volumen_off;
			mute = true;
		}
	}

	public void abrir_ayuda()
	{
		btn_superior.SetActive (false);
		btn_inferior.SetActive (false);
	}

	public void cerrar_ayuda()
	{
		btn_superior.SetActive (true);
		btn_inferior.SetActive (true);
	}
}
