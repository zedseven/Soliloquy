using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float minMoveHeight = -2.0f;
	public float maxMoveHeight = 4.0f;
	
	private float distToGround = 0.0f;
	
	public GameObject main = null;
	
	/*void Start()
	{
		distToGround = gameObject.GetComponent<Collider2D>().bounds.extents.y;
	}

	bool IsGrounded()
	{
		return Physics2D.Raycast(transform.position + new Vector3(0, -distToGround - 0.0001f, 0), -Vector3.up, distToGround + 0.1f);
	}*/
	
	void Update()
	{
		if(StaticPaused.paused == false)
		{
			/*Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
			//rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
			if(Input.GetButtonDown("Jump") && IsGrounded())
			{
				//rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
				rb.AddForce(new Vector2(0.0f, jumpHeight));
			}*/
			Vector3 pos = Input.mousePosition;
			pos.z = 0.0f;
			pos = Camera.main.ScreenToWorldPoint(pos);
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(pos.y, minMoveHeight, maxMoveHeight), transform.position.z);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(StaticPaused.paused == false)
		{
			if(other.gameObject.tag == "Obstacle")
			{
				main.GetComponent<ObstacleSpawner>().DestroyObstacle(other.gameObject);//Destroy(other.gameObject);
				main.GetComponent<QuestionScript>().PrepForQuestion();
				main.GetComponent<QuestionScript>().AskQuestion();
			}
		}
	}
}