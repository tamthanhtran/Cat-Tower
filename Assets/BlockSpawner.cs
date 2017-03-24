using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {
	public GameObject blockPrefab;
	
	private GameObject swingingHand;
	//private bool spawnEmpty = false;
	
	// Use this for initialization
	void Start () {
		swingingHand = GameObject.Find("SwingingHand");
		SpawnNewBlock();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.childCount <= 1)
		{
			//Invoke("SpawnNewBlock",1.0f);
			SpawnNewBlock();
			//Debug.Log(transform.childCount);
		}
		
	}
	
	void SpawnNewBlock()
	{
		GameObject newBlock = Instantiate(blockPrefab, swingingHand.transform.position, Quaternion.identity) as GameObject;
		newBlock.transform.parent = this.transform;
	}
}
