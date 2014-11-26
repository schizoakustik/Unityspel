using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GameObject optionsPanel;
	public bool menuOn = false;


	public void openOptionsMenu() {
		menuOn = !menuOn;
		if (menuOn) {
			Time.timeScale = 0.01f;
			optionsPanel.gameObject.SetActive(menuOn);
		}
		else {
			Time.timeScale = 1;
			optionsPanel.gameObject.SetActive(menuOn);
			}
		Debug.Log(menuOn);
			
			
	}
}
