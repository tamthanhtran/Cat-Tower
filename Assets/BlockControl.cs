using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {
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
		if (Input.GetMouseButtonDown(0))
		{
			isSwinging = false;
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.tag == "Block" && !rigidbody2D.isKinematic){
			transform.parent = blockTower.transform;
			
			//Fix block location if the tower
			this.rigidbody2D.isKinematic = true;
			
			//Avoid tilting block
			this.transform.localEulerAngles = new Vector3(0,0,0);
			
			foreach(Transform child in blockTower.transform)
			{
				child.position += new Vector3(0f, -1.1f, 0f);
			}
			
			
		}
		
	}
}
