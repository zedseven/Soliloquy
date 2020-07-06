using UnityEngine;
using System.Collections;

public class ObstacleRemover : MonoBehaviour
{
	public GameObject main = null;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Obstacle")
		{
			main.GetComponent<ObstacleSpawner>().DestroyObstacle(other.gameObject);//Destroy(other.gameObject);
		}
	}
}
