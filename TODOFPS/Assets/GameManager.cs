using UnityEngine;
using UnityEngine.SceneManagement;
//20th may 2016 start git test

public class GameManager : MonoBehaviour {

	void Update () {
		//Restart button:
		if(Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(0);
		} else if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}//end of class