using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

	public GameObject hoverSound;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void StartButtonClicked()
	{

		Invoke ("LoadDelayed", 0.2f);

	}

	public void LoadDelayed()
	{


		SceneManager.LoadScene ("MainScene");
	}

	public void ExitGame ()
	{
		#if UNITY_STANDALONE
		Application.Quit ();
		#endif
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void PlayHover ()
	{
		hoverSound.GetComponent<AudioSource> ().Play ();
	}

}
