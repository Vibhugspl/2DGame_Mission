using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms;
using System;


public class SaveLoad 
{
	public static void saveplayer(Gameplay player)
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath+"/Gemplay.sav",FileMode.Create);
		 
	}

}
[Serializable]
public class userData
{
	public List<string> username=new List<string>();
	public List<string> passward = new List<string> ();

	public userData(Gameplay player)
	{
		//username.Add (player.userName.);
	}
}