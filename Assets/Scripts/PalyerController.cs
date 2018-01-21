using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalyerController : MonoBehaviour {


	private Rigidbody2D rb2d;       
	public float speed;
	public Text CountText;
	public Text WinText;
	private int count;

	void Start()
	{
	     rb2d = GetComponent<Rigidbody2D> ();
		 count = 0;
		 WinText.text = "";
		 SetCountText ();
	}

	void FixedUpdate()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");

		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);


		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}


	}

	void SetCountText ()
	{
		CountText.text = "Count: " + count.ToString ();
		if (count >= 12)
			WinText.text = "You win!";
	}





}
