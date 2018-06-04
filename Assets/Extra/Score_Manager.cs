using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour 
{
	public List<PlayerPrefs> score;





	void Start()
	{
		score = new List<PlayerPrefs> ();
	}

	public void Restart()
	{
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
	}

	void restart ()
	{
		SceneManager.LoadScene (0);
		print ("Reset");
	}

	public void Pause()
	{
		Time.timeScale = 0;
	}

	public void play()
	{
		Time.timeScale = 1;
	}

	public void Exit_Game()
	{
		Application.Quit ();
	}
}
