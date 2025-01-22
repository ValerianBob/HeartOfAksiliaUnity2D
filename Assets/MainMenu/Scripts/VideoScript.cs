using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource musicMainMenu;
    public GameObject buttonsMain;

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("Video Player не назначен!");
            return;
        }

        videoPlayer.Play();
        musicMainMenu.volume = 0;
        videoPlayer.loopPointReached += OnVideoEnd;
    }


    private void OnVideoEnd(VideoPlayer vp)
    {
        gameObject.SetActive(false);
        musicMainMenu.volume = 0.1f;
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoEnd;

    }
}