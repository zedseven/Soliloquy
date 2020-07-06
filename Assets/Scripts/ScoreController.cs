using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UIText = UnityEngine.UI.Text;
public class ScoreController : MonoBehaviour
{
	public float score = 0.0f;
	
	public GameObject scoreText = null;
	
	void Update()
	{
		if(StaticPaused.paused == false)
		{
			score += Time.deltaTime;
			scoreText.GetComponent<UIText>().text = "Score: " + score.ToString("F2");
		}
	}
}