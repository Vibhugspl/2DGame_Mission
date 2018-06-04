using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MynameSpace
{
	public class MyFunctions :MonoBehaviour
	{
		public static Dictionary<string,int> removeDuplicates(Dictionary<string,int> Input_dict)
		{
			for (int i = 0; i < Input_dict.Count; i++)
			{
				for (int j = i + 1; j < Input_dict.Count; j++) 
				{
					//Input_dict.ContainsValue [i] Input_dict.ContainsValue [j];
				}
			}
			return Input_dict;
		}

	
	}
}