using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleAudioEffect : MonoBehaviour
{
	public AudioSource audioSource;
	public float updateStep = 0.1f;
	public int sampleDataLength = 1024*3;

	private float currentUpdateTime = 5f;

	public float clipLoudness;
	private float[] clipSampleData;

	public float sizeFactor = 1;

	public float minSize = 0;
	public float maxSize = 500;
	// Start is called before the first frame update
	void Start()
    {
		clipSampleData = new float[sampleDataLength];
	}

    // Update is called once per frame
    void Update()
    {
		currentUpdateTime += Time.deltaTime;
		if (currentUpdateTime >= updateStep)
		{
			currentUpdateTime = 0f;
			audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
			clipLoudness = 0f;
			foreach (var sample in clipSampleData)
			{
				clipLoudness += Mathf.Abs(sample);
			}
			clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
			clipLoudness *= sizeFactor;
			clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
			//sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
			this.GetComponent<ParticleSystem>().startSpeed = clipLoudness;
		}
	}
}
