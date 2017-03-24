using UnityEngine;
using System.Collections;

public class BlockTowerController : MonoBehaviour {
	public float swingSpeed = 0;
	public float padding = 1;
	
	private int direction = 1;
	private float boundaryRightEdge, boundaryLeftEdge;
	
	
	// Use this for initialization
	void Start () {
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		float formationRightEdge = transform.position.x + 0.5f;
		float formationLeftEdge = transform.position.x - 0.5f;
		if (formationRightEdge > boundaryRightEdge){
			direction = -1;
			}
		if (formationLeftEdge < boundaryLeftEdge){
			direction = 1;
		}
		transform.position += new Vector3(direction * 0f * Time.deltaTime,0,0);
	}
}
