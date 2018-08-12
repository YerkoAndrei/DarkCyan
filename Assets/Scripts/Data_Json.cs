using UnityEngine;
using System.IO;

public class Data_Json : MonoBehaviour {

	public static void guardar (int puntaje) {
		Data_DarkCyan data = new Data_DarkCyan ();
		data.puntaje = puntaje.ToString ();
		string json = JsonUtility.ToJson (data);
		File.WriteAllText (Application.persistentDataPath + "DarkCyan.json", json);
	}
	public static int cargar () {
		Data_DarkCyan data = JsonUtility.FromJson<Data_DarkCyan> (File.ReadAllText(Application.persistentDataPath + "DarkCyan.json"));
		return System.Convert.ToInt32(data.puntaje);
	}
}

public class Data_DarkCyan
{
	public string puntaje;
}
