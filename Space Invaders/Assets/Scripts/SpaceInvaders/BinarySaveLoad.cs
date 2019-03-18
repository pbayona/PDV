using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySaveLoad{ //Script con 2 métodos, el primero permite guardar una lista de usuarios recibida como argumento
	//El segundo método deserializa el archivo binario escrito y lo recupera a lista de usuarios

	public static void SaveUsers(List<User> users)
	{
		BinaryFormatter formatter = new BinaryFormatter ();
		string path = Application.persistentDataPath + "/users";
		FileStream stream = new FileStream (path, FileMode.Create);
		formatter.Serialize (stream, users);
		stream.Close();
	}

	public static List<User> LoadUsers()
	{
		string path = Application.persistentDataPath + "/users";
		if (File.Exists (path)) {
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream stream = new FileStream (path, FileMode.Open);
			//List<User> aux = (List<User>)formatter.Deserialize (stream);
			List<User> aux = formatter.Deserialize (stream) as List<User>;
			stream.Close();
			return aux;
		} else {
			Debug.LogError ("Save file not found in " + path);
			return null;
		}	
	}

}
