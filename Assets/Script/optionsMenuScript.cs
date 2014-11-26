using UnityEngine;
using System.Collections;

public class optionsMenuScript : MonoBehaviour {
	//	public GUIStyle optionsMenuButton;

	// 	public GameObject gameController = GameObject.Find("GameControllerObject");

	public GUISkin pixelGUI;

	//bool endlessMode;
	
	void Start() {
	//	endlessMode = gameController.GetComponent<GameControllerScript>().endlessMode;
		}
	
	void OnGUI() {
		GUI.skin = pixelGUI;

		float groupWidth = 400;
		float groupHeight = 200;

		float screenWidth = Screen.width;
		float screenHeight = Screen.height;

		float groupX = ((screenWidth - groupWidth) / 2);
		float groupY = ((screenHeight - groupHeight) / 2);

		GUI.BeginGroup (new Rect(groupX, (groupY - 50), groupWidth, groupHeight));

		GUI.Box (new Rect(0, 0, groupWidth, groupHeight), "");

		// GUI.Label (new Rect(0, 0, (groupWidth - 200), 50), "Music", "button");
		if (GUI.Button (new Rect(0, 0, groupWidth, 50), "MUSIC")) {
			// TODO: Enable/disable music
			if (audio.isPlaying)
				audio.Pause();
			else
				audio.Play();
		}
		
			if (GUI.Button (new Rect(0, 50, groupWidth, 50), "ENDLESS MODE")) {
					// TODO: Switch between first-to-5 and endless.
					// TODO: More options? First-to-three/ten...?
			}

			if (GUI.Button (new Rect(0, 100, groupWidth, 50), "SELECT BACKGROUND", "button")) {
					// TODO: Background selection
			}
				
			if (GUI.Button (new Rect(0, 150, groupWidth, 50), "BACK", "button"))
					Application.LoadLevel(1);
		
		GUI.EndGroup();
		
	}
}
