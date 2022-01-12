using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class audiovisualization : MonoBehaviour
{
    public GameObject videoplayer;

    private AudioSource audioSource;

    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public GameObject sprite;
    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;


    public int position = 0;
    public int samplerate = 44100;
    public float frequency = 440;
    // Start is called before the first frame update
    void Start()
    {
       /* if(videoplayer.GetComponent<VideoPlayer>().audioOutputMode == VideoAudioOutputMode.AudioSource)
        {
            audioSource = videoplayer.GetComponent<VideoPlayer>().GetTargetAudioSource(0);
            Debug.Log("Got audio source.");
        }*/
        
    }
    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];

        var samplesLength = AudioSettings.outputSampleRate; // 1 sec worth of looping buffer

        if (videoplayer.GetComponent<VideoPlayer>().audioOutputMode == VideoAudioOutputMode.AudioSource)
        {
            audioSource = videoplayer.GetComponent<VideoPlayer>().GetTargetAudioSource(0);
            Debug.Log("Got audio source.");
            
            audioSource.clip = AudioClip.Create("", samplesLength, 2, AudioSettings.outputSampleRate, true, OnAudioRead);
            if (audioSource.clip != null)
            Debug.Log("Created audio clip");
        }
        
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
            sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
        }
        
        //Debug.Log(audioSource.clip);
    }

    void OnAudioRead(float[] data)
    {
        
        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
            Debug.Log(data[count]);
            position++;
            count++;
        }
    }
}
