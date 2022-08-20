using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionsController : MonoBehaviour
{
    public CanvasRenderer background;
    public CanvasRenderer phrase;
    public RectTransform phraseRect;
    public AudioSource speaker;
    public float fadeDuration, phraseGap, audioGap, audioOutDelay, animationRange;
    public List<Texture> backgrounds;
    public List<Texture> phrases;
    public List<AudioClip> audios;

    private int _actualPos = 0;

    public void Start ()
    {
        background.SetAlpha(0);
        phrase.SetAlpha(0);

        StartCoroutine(StartTransitions());
    }

    public IEnumerator StartTransitions ()
    {
        while (true)
        {
            background.SetTexture(backgrounds[_actualPos]);
            Texture phraseTex = phrases[_actualPos];
            phrase.SetTexture(phraseTex);
            phraseRect.sizeDelta = new Vector2(phraseTex.width / 2.0f, phraseTex.height/2.0f);
            speaker.clip = audios[_actualPos];
            
            float timer = Time.time;
            while (background.GetAlpha() < 1)
            {
                float alpha = Mathf.Lerp(0, 1, (Time.time - timer) * fadeDuration);
                background.SetAlpha(alpha);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(phraseGap);

            timer = Time.time;
            float yStart = phraseRect.transform.localPosition.y;
            Vector3 startPosition = phraseRect.transform.localPosition;
            Vector3 endPosition = phraseRect.transform.localPosition;
            startPosition.y = yStart - animationRange;
            while (phrase.GetAlpha() < 1)
            {
                phraseRect.transform.localPosition = Vector3.Lerp(startPosition, endPosition, (Time.time - timer) * fadeDuration);
                float alpha = Mathf.Lerp(0, 1, (Time.time - timer) * fadeDuration);
                phrase.SetAlpha(alpha);
                yield return new WaitForEndOfFrame();
            }
            
            yield return new WaitForSeconds(audioGap);

            speaker.Play();
            yield return new WaitUntil(() => !speaker.isPlaying);

            yield return new WaitForSeconds(audioGap + audioOutDelay);

            timer = Time.time;
            yStart = phraseRect.transform.localPosition.y;
            startPosition = phraseRect.transform.localPosition;
            endPosition = phraseRect.transform.localPosition;
            endPosition.y = yStart + animationRange;
            while (phrase.GetAlpha() > 0)
            {
                phraseRect.transform.localPosition = Vector3.Lerp(startPosition, endPosition, (Time.time - timer) * fadeDuration);
                float alpha = Mathf.Lerp(1, 0, (Time.time - timer) * fadeDuration);
                phrase.SetAlpha(alpha);
                yield return new WaitForEndOfFrame();
            }
            phraseRect.transform.localPosition = startPosition;

            yield return new WaitForSeconds(phraseGap);
            
            timer = Time.time;
            while (background.GetAlpha() > 0)
            {
                float alpha = Mathf.Lerp(1, 0, (Time.time - timer) * fadeDuration);
                background.SetAlpha(alpha);
                yield return new WaitForEndOfFrame();
            }

            _actualPos++;
            _actualPos %= backgrounds.Count;
        }
    }
}
