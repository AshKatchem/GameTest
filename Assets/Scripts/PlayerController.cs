using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Text counter;
	public Text winText;
	public float speed;
	private int count;
	
	Rigidbody rb;
	Vector3 mov;

	void Start()
	{
		count = 0;
		rb = GetComponent<Rigidbody> ();
		editCount (count);
		winText.text = "";
	}

	void Update() {
		/*if (Application.isMobilePlatform) 
		{
			mov = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y).normalized * speed;

		} else 
		{
		*/
			mov = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * speed;
			
		//} 
	}

	void FixedUpdate()
	{

		Vector3 mov2 = mov * Time.fixedDeltaTime;
		rb.MovePosition (rb.position + mov2);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup")) 
		{
			other.gameObject.SetActive (false);
			count++;
			editCount(count);
		}
	}
	void editCount(int i)
	{
		counter.text = "Count: " + i.ToString ();
		if (count >= 16) 
		{
			//winText.text = "You Won!";
		}
	}
}