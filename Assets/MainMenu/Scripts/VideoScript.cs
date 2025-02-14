using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource musicMainMenu;

    void Start()
    {
        if (videoPlayer == null )
        {
            Debug.LogError("Video Player не назначен!");
            return;
        }

        gameObject.SetActive(false);
        if (OptionsConfig.Instance.firstEnterGame != true)
        {
            Cursor.visible = false;
            gameObject.SetActive(true);
            videoPlayer.Play();
            OptionsConfig.Instance.firstEnterGame = true;
            musicMainMenu.volume = 0;
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }


    private void OnVideoEnd(VideoPlayer vp)
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
        musicMainMenu.volume = 0.1f;
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoEnd;
    }
}