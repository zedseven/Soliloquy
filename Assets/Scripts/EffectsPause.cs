using UnityEngine;
using System.Collections;

public class EffectsPause : MonoBehaviour
{
	void Update()
	{
		ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
		if(StaticPaused.paused == true && ps.isPlaying == true)
		{
			ps.Pause(false);
		}
		else if(StaticPaused.paused == false && ps.isPaused == true)
		{
			ps.Play(false);
		}
	}
}