using UnityEngine;
using System.Collections;

public class ObstacleMover : MonoBehaviour
{
	public float moveVelocity = 5.0f;
	void Update()
	{
		if(StaticPaused.paused == false)
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, 0.0f);//moveVelocity * (gameObject.GetComponent<Rigidbody2D>().velocity.normalized);
		}
		else
		{
			gameObject.GetComponent<Rigidbody2D>().velocity= Vector3.zero;
		}
	}
}
