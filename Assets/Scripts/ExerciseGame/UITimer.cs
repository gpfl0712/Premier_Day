using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
	private float Timer = 45.0f;

	public float GetTime()
	{
		return Timer;
	}

	public float AddTime(float time)
	{
		return Timer += time;
	}

	void Update()
	{
		Timer -= Time.deltaTime;
		if (Timer < 0)
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
			return;
		}
		int seconds = Mathf.FloorToInt(Timer % 60F);
		int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
		GetComponent<TMP_Text>().text = seconds.ToString("00") + ":" + milliseconds.ToString("00");
	}
}
