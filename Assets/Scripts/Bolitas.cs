using UnityEngine;

public class Bolitas : MonoBehaviour {

	public Sprite color_1;
	public Sprite color_2;

	public AudioSource fuente;
	public AudioClip sonido_1;	
	public AudioClip sonido_2;
	public AudioClip sonido_3;
	public AudioClip sonido_4;

	private Vector2 centro;				// El "Centro" siempre esta en el (0,0)
	private float vel;					// Velocidad de la bolita
	private bool tipo;					// true = Celeste

	void Start () {
		centro = new Vector2 (0, 0);

		// Tipo de bolita
		float aleatorio = Random.Range (0, 100);
		if (aleatorio < 70) {
			tipo = true;
			vel = 2.5f;
			gameObject.GetComponent<SpriteRenderer>().sprite = color_1;
		} else {
			tipo = false;
			vel = 5.0f;
			gameObject.GetComponent<SpriteRenderer>().sprite = color_2;
		}
	}

	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, centro, vel * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Puntaje
		if (col.gameObject.name == "Espada") {
			if (tipo) {
				Menu_index.puntaje += 1;
				fuente.Play ();
				fuente.PlayOneShot(sonido_1);
			} else {
				Menu_index.puntaje += 2;
				fuente.Play ();
				fuente.PlayOneShot(sonido_2);
			}
			Destroy (GetComponent<SpriteRenderer> ());
			Destroy (GetComponent<CircleCollider2D> ());
			Destroy (gameObject, 0.2f);
		}

		// Daño 
		if (col.gameObject.name == "Centro") {
			if (tipo) {
				Menu_index.vida -= 2;
				fuente.PlayOneShot(sonido_4);
			} else {
				Menu_index.vida -= 1;
				fuente.PlayOneShot(sonido_3);
			}
			Destroy (GetComponent<SpriteRenderer> ());
			Destroy (GetComponent<CircleCollider2D> ());
			Destroy (gameObject, 0.2f);
		}
	}
}