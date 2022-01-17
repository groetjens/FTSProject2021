using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncContent : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer VideoPlayer;
    public UnityEngine.AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer.Prepare();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VideoPlayer.isPlaying)
        {

        } else if (VideoPlayer.isPrepared)
        {
            VideoPlayer.Play();
            AudioSource.Play();
            StartCoroutine(FindObjectOfType<SubtitleDisplayer>().Begin());
        }
    }
}
