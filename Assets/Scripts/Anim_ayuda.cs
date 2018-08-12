using UnityEngine;

public class Anim_ayuda : MonoBehaviour {

	public GameObject centro_tap;
	public GameObject centro_hold;
	public GameObject espada_tap;
	public GameObject espada_hold;

	private Vector3 eje = new Vector3 (0, 0, 1);

	private float tempo_tap;
	private float tempo_tap_pred = 1.0f;
	private float tempo_hold;
	private float tempo_hold_pred = 2.0f;

	private float f_centro_tap = -1.0f;
	private float f_centro_hold = -1.0f;

	private float f_espada_tap = 2.0f;
	private float f_espada_hold;

	private float f_espada_hold_pred = 2.0f;
	private float f_espada_hold_doble = 6.0f;

	private float mov_hold;
	private float mov_hold_pred = 1.0f;

	public GameObject menu_principal;
	public GameObject menu_ayuda;
	public GameObject anim_ayuda;
	public GameObject btn_superior;
	public GameObject btn_inferior;

	void Start () {
		tempo_tap = tempo_tap_pred;
		tempo_hold = tempo_hold_pred;
		f_espada_hold = f_espada_hold_pred;
		mov_hold = mov_hold_pred;
	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			menu_principal.SetActive (true);
			btn_superior.SetActive (true);
			btn_inferior.SetActive (true);
			menu_ayuda.SetActive (false);
			anim_ayuda.SetActive (false);
		}

		tempo_tap -= Time.deltaTime;
		tempo_hold -= Time.deltaTime;

		// Mov tap
		if (tempo_tap <= 0.0f) {
			f_centro_tap = f_centro_tap * -1;
			f_espada_tap = f_espada_tap * -1;
			tempo_tap = tempo_tap_pred;
		}

		// Mov hold
		if (tempo_hold <= 0.0f) {
			f_espada_hold = f_espada_hold_doble;
			mov_hold -= Time.deltaTime;
		}
		if (mov_hold <= 0.0f) {
			f_espada_hold = f_espada_hold_pred;
			mov_hold = mov_hold_pred;
			tempo_hold = tempo_hold_pred;
		}
		
		// Movimiento
		centro_tap.transform.RotateAround (centro_tap.transform.position, eje, f_centro_tap);
		centro_hold.transform.RotateAround (centro_hold.transform.position, eje, f_centro_hold);

		espada_tap.transform.RotateAround (centro_tap.transform.position, eje, f_espada_tap);
		espada_hold.transform.RotateAround (centro_hold.transform.position, eje, f_espada_hold);
	}
}
