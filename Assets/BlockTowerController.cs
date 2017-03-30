using UnityEngine;
using System.Collections;

public class BlockTowerController : MonoBehaviour {
	public float swingAttribute = 0;
	public float padding = 1;
	
	private int direction = 1;
	private float boundaryRightEdge, boundaryLeftEdge;
	private float rightEdge, leftEdge;
	//private ScoreKeeper scoreKeeper;
	
	// Use this for initialization
	void Start () {
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
		Debug.Log(boundaryLeftEdge);
		Debug.Log(boundaryRightEdge);
		//scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		swingAttribute = ScoreKeeper.towerMismatch;
		float formationRightEdge = transform.position.x;
		float formationLeftEdge = transform.position.x;
		
		rightEdge = Mathf.Min(swingAttribute, boundaryRightEdge) - BlockControl.topBlockOffset;
		leftEdge = Mathf.Max (-swingAttribute, boundaryLeftEdge) - BlockControl.topBlockOffset;

		
		if (formationRightEdge > rightEdge){
			direction = -1;
			}
		if (formationLeftEdge < leftEdge){
			direction = 1;
		}
		
		transform.position += new Vector3(direction * swingAttribute * Time.deltaTime,0,0);
	}
}
