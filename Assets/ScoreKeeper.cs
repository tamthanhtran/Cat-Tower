using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	public static float towerMismatch = 0;
	public int nonSwingHeight = 5;
	public int speedDivider = 3;
	public float maxError = 5;
	
	private Text myText;
	
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Score(int points, float blockMismatch){
		//Debug.Log ("Scored points");
		score += points;
		if (score > nonSwingHeight){
			if (towerMismatch < maxError)
			{
				towerMismatch += blockMismatch/speedDivider;
			}
		}
		Debug.Log("Tower mismatch = " + towerMismatch);

		myText.text = score.ToString();
	}
	
	public static void Reset(){
		score = 0;
	}
}
