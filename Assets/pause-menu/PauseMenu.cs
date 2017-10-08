using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pausePanel;
	public GameObject mask;
	public GameObject hoverSound;

	// Use this for initialization
	void Start () 
	{
		SetPausePanel (false);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.active == false)
		{
			SetPausePanel (true);
			Time.timeScale = 0;

		}
		else if(Input.GetKeyDown(KeyCode.Escape) && pausePanel.active == true) 
		{
			SetPausePanel (false);
			Time.timeScale = 1;
		}
		
	}

	public void SetPausePanel (bool sign)
	{
		pausePanel.SetActive(sign);
		mask.SetActive(sign);
	}

	public void ExitGameButton ()
	{
		#if UNITY_STANDALONE
		Application.Quit ();
		#endif
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void ResumeButton ()
	{
		SetPausePanel (false);
		Time.timeScale = 1;
	}

	public void ResturtButton ()
	{
		SceneManager.LoadScene ("MainScene");
		Time.timeScale = 1;
	}

	public void PlayHover ()
	{
		hoverSound.GetComponent<AudioSource> ().Play ();
	}
}
