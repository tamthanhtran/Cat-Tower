using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {
	public static float topBlockOffset = 0;
	public float standardDistanceToSpawner = 6f;
	public int scoreValue = 1;
	
	private GameObject swingingHand;
	private GameObject blockTower;
	private ScoreKeeper scoreKeeper;
	
	private bool isSwinging = true;
	// Use this for initialization
	void Start () {
		swingingHand = GameObject.Find("SwingingHand");
		blockTower = GameObject.Find("BlockTower");
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isSwinging)
		{
			transform.position = swingingHand.transform.position;
		}
		if (Input.GetMouseButtonDown(0) && isSwinging)
		{
			isSwinging = false;
			transform.rigidbody2D.isKinematic = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		float blockMismatch = 0;
		
		if (coll.gameObject.tag == "Tower" && coll.transform.rigidbody2D.isKinematic && !coll.transform.collider2D.isTrigger){
			transform.parent = blockTower.transform;
			
			blockMismatch = transform.position.x - coll.transform.position.x;
			if( Mathf.Abs(blockMismatch) <= coll.transform.collider2D.bounds.size.x * 0.65){
				if(transform.position.y > coll.transform.position.y){
					coll.transform.collider2D.isTrigger = true;
					scoreKeeper.Score(scoreValue, Mathf.Abs(blockMismatch));
					
					//coll.transform.renderer.material.color = Color.blue;
					AddNewBLockToTower();
				}				
			}
			else {
				transform.rigidbody2D.fixedAngle = false;
			}
						
		}
		
	}
	
	private void AddNewBLockToTower(){
		this.tag = "Tower";
		//Fix block location if the tower
		this.rigidbody2D.isKinematic = true;
		
		topBlockOffset = transform.localPosition.x;
		Debug.Log("topblock = " + topBlockOffset);
	
		//Avoid tilting block
		this.transform.localEulerAngles = new Vector3(0,0,0);
		
		foreach(Transform child in blockTower.transform)
		{
			child.position += new Vector3(0f, CalculateDistanceAdjustment(), 0f);
			//				Debug.Log(transform.renderer.bounds.size.y);
			
		}
		
	}
	
	private float CalculateDistanceAdjustment(){
		float distanceToSpawner;
		float distanceAdjustment = 0;
		distanceToSpawner = swingingHand.transform.parent.transform.position.y - transform.position.y;
//		Debug.Log(distanceToSpawner);
		if (distanceToSpawner < standardDistanceToSpawner){
			distanceAdjustment = distanceToSpawner - standardDistanceToSpawner;
		}
		return distanceAdjustment;
	}
}
