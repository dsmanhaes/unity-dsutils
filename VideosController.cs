using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideosController : MonoBehaviour
{
    public VideoPlayer[] videos;

    private bool _isPlaying = false;

    public void Start ()
    {
        foreach (VideoPlayer video in videos)
        { StartCoroutine(AsyncShowFirstFrame(video)); }
    }

    public void Play ()
    { if (!_isPlaying) StartCoroutine(AsyncPlayAll()); }

    private IEnumerator AsyncPlayAll ()
    {
        _isPlaying = true;
        double videosLength = 0;
        foreach (VideoPlayer video in videos)
        {
            video.Stop();
            video.Play();
            if (video.clip.length > videosLength)
                videosLength = video.clip.length;
        }
        yield return new WaitForSeconds((float)videosLength);
        foreach (VideoPlayer video in videos)
        { StartCoroutine(AsyncShowFirstFrame(video)); }
        _isPlaying = false;
    }

    private IEnumerator AsyncPlayInChain ()
    {
        _isPlaying = true;
        foreach (VideoPlayer video in videos)
        {
            video.Stop();
            video.Play();
            yield return new WaitForSeconds((float)video.clip.length);
        }
        _isPlaying = false;
    }

    private IEnumerator AsyncShowFirstFrame (VideoPlayer video)
    {
        video.Stop();
        video.Play();
        yield return new WaitForFixedUpdate();
        video.Pause();
    }
}
