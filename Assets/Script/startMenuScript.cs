using UnityEngine;
using System.Collections;

public class startMenuScript : MonoBehaviour {

	public GUISkin pixelGUI;

	void OnGUI() {
		GUI.skin = pixelGUI;

		float groupWidth = 400;
		float groupHeight = 150;

		float screenWidth = Screen.width;
		float screenHeight = Screen.height;

		float groupX = ((screenWidth - groupWidth) / 2);
		float groupY = ((screenHeight - groupHeight) / 2);

		GUI.BeginGroup (new Rect(groupX, (groupY - 50), groupWidth, groupHeight));
		GUI.Box (new Rect(0, 0, groupWidth, groupHeight), "");
		
		if (GUI.Button (new Rect(0, 0, groupWidth, 50), "Start Game", "button")) {
			Application.LoadLevel(2);
			}
			
		
		if (GUI.Button (new Rect(0, 50, groupWidth, 50), "Options", "button")) {
			Application.LoadLevel(1);
			}
		
		if (GUI.Button (new Rect(0, 100, groupWidth, 50), "Exit Game", "button")) {
			Application.Quit();
			}
		
		GUI.EndGroup();
	}
}
