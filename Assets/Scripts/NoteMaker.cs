using UnityEngine;
using System.Collections;

public class NoteMaker : MonoBehaviour {
	public GameObject[] Notes;
	GameObject newNote;

	float dist;
	//Vector4 camBoundary;
	float boundaryRight;

	void Awake() {
		dist = (transform.position - Camera.main.transform.position).z;

		//Get Right Boundary
		//camBoundary.x = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
		boundaryRight = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (true == CheckNext())
			newNote = MakeNote ();
	}

	bool CheckNext()
	{
		if (null != newNote) {
			float posX = newNote.transform.position.x;
			float sizeW = newNote.GetComponent<Collider2D>().bounds.size.x;
			if (posX + sizeW > boundaryRight)
				return false;
		}

		return true;
	}

	GameObject MakeNote()
	{
		int randIndex = Random.Range (0, Notes.Length);
		GameObject note = Instantiate (Notes [randIndex]) as GameObject;
		float noteSizeW = note.GetComponent<Collider2D>().bounds.size.x;
		note.transform.position = new Vector3 (boundaryRight + noteSizeW, 0, 0);
		return note;
	}
}
