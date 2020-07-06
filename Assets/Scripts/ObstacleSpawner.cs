using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
	public Object obstacle = null;
	public float minSpawnTime = 0.5f;
	public float maxSpawnTime = 1.0f;
	public float minSpawnHeight = 0.5f;
	public float maxSpawnHeight = 2.5f;
	
	private float spawnTimer = 0.0f;
	private float nextSpawnTime = 1.0f;
	
	public int reqdAmntObstacles = 15;
	private GameObject[] obstaclePool = new GameObject[0];
	
	void Update()
	{
		if(StaticPaused.paused == false)
		{
			if(spawnTimer >= nextSpawnTime)
			{
				spawnTimer = 0.0f;
				nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
				SpawnObstacle();
			}
			spawnTimer += Time.deltaTime;
		}
	}
	
	public void SetNSpawnTime(float nSpawn)
	{
		nextSpawnTime = nSpawn;
	}
	
	void SpawnObstacle()
	{
		GameObject newObstacle = null;
		if(obstaclePool.Length < reqdAmntObstacles)
		{
			newObstacle = (GameObject) Instantiate(obstacle);
			obstaclePool = AddItemToArray(obstaclePool, newObstacle);
		}
		else
		{
			newObstacle = GetUnusedObstacle();
			newObstacle.SetActive(true);
		}
		
		if(newObstacle != null)
		{
			newObstacle.name = "Obstacle";
			newObstacle.transform.position = new Vector3(50.0f, Random.Range(minSpawnHeight, maxSpawnHeight), 0.0f);
			newObstacle.transform.localEulerAngles = new Vector3(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
		}
		else
		{
			Debug.LogError("There are no obstacles available in the pool to use!");
		}
	}
	
	public void DestroyObstacle(GameObject dObstacle)
	{
		dObstacle.SetActive(false);
	}
	
	GameObject GetUnusedObstacle()
	{
		for(int i = 0; i < obstaclePool.Length; i++)
		{
			if(obstaclePool[i].active == false)
			{
				return obstaclePool[i];
			}
		}
		return null;
	}
	
	//for adding to the obstaclePool
	private GameObject[] AddItemToArray(this GameObject[] original, GameObject itemToAdd)
	{
		GameObject[] finalArray = new GameObject[original.Length + 1];
		for(int i = 0; i < original.Length; i++)
		{
			finalArray[i] = original[i];
		}
		finalArray[finalArray.Length - 1] = itemToAdd;
		return finalArray;
	}
}