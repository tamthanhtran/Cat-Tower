using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {
	public float standardDistanceToSpawner = 6f;
	private GameObject swingingHand;
	private GameObject blockTower;
	
	private bool isSwinging = true;
	// Use this for initialization
	void Start () {
		swingingHand = GameObject.Find("SwingingHand");
		blockTower = GameObject.Find("BlockTower");
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
			if( Mathf.Abs(blockMismatch) <= coll.transform.collider2D.bounds.size.x * 0.5){
				if(transform.position.y > coll.transform.position.y){
					coll.transform.collider2D.isTrigger = true;
					coll.transform.renderer.material.color = Color.blue;
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
