using UnityEngine;
using System.Collections;

public class NoteMove : MonoBehaviour {
	public Vector2 speed;
	public Vector2 direction;

	float dist;
	float boundaryLeft;

	void Awake()
	{
		dist = (transform.position - Camera.main.transform.position).z;
		boundaryLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
	}
	// Use this for initialization
	void Start () {

		speed = new Vector2 (0.1f, 0);
		direction = new Vector2 (-1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curPos = transform.position;
		float newPosX = curPos.x + speed.x * direction.x;
		float newPosY = curPos.y + speed.y * direction.y;
		Vector3 newPos = new Vector3(newPosX, newPosY, curPos.z);
		transform.position = newPos;

		//Check if it is out of Screen
		float sizeW = GetComponent<Collider2D>().bounds.size.x; 
		if (newPosX + sizeW < boundaryLeft)
			Destroy(gameObject);
	}
}
