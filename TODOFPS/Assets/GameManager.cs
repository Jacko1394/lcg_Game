using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	void Update () {
		//Restart button:
		if(Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(0);
		} else if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}//END OF FILE
