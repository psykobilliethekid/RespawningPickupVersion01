using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	//Variables
	private bool clockIsPaused = false;
	private float startTime;      //in seconds
	private float timeRemaining;  //in seconds

	private bool guiIsOn = false;

	private void Awake()
	{
		startTime = Time.time + 60.0f;
		Time.timeScale = 1;

	}
	
	void Update () 
	{
		if(!clockIsPaused)
		{
			//making sure the timer is not paused
			 DoCountdown ();
		}
	}

	private void DoCountdown()
	{
		timeRemaining = startTime - Time.time;

		if (timeRemaining < 0)
		{
			timeRemaining = 0;
			clockIsPaused = true;
			TimeIsUp();
			guiIsOn = true;
			Time.timeScale = 0;
		}

		ShowTime();
		Debug.Log ("time remaining = " + timeRemaining);
	}


	private void PauseClock()
	{
		clockIsPaused = true;
	}

	private void UnPauseClock()
	{
		clockIsPaused = false;
	}

	private void ShowTime()
	{
		int minutes;
		int seconds; 
		string timeStr;
		minutes = (int) (timeRemaining/60);
		seconds = (int) (timeRemaining % 60);
		timeStr = minutes.ToString() + " : ";
		timeStr += seconds.ToString("D2");
		guiText.text = timeStr;   //display the time on the GUI
	}

	private void TimeIsUp()
	{
		Debug.Log ("Time is up!");

	}
	
	void OnGUI()
	{ 
		if (guiIsOn)
			{
			// Make a background box
			GUI.Box(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 90), "TIME!");
			
			// Make the first button. If it is pressed, Application.LoadLevel(Application.loadedLevel) will be executed
			if(GUI.Button(new Rect(Screen.width/2-40, Screen.height/2+10,80,20), "Play Again?")) 
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
