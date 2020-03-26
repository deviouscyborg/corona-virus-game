using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private int score;

	public Text scoreText;

 	void Start(){
     		score = 0;
 		}
	

		 
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
			if (Input.GetMouseButtonDown(0)) {
			 score++;
		 }
		scoreText.text = score.ToString();
	}
}
