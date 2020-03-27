using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int score = -1;

	public Text scoreText;

 	void Start(){
 		}
	

		 
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
	}
}
