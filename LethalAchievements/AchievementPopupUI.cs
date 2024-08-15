using System.Collections;
using LethalAchievements;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopupUI : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public Image iconImage;
    public GameObject iconError;
    public float fadeDuration = 2f;
    public float stayDuration = 5f;
    public AudioSource audioSource;

    public void SetDetails(string name, string description, Sprite icon)
    {
        nameText.text = name;
        descriptionText.text = description;
        if (icon != null)
        {
            iconImage.sprite = icon;
            iconError.SetActive(false);
        }
        else
        {
            iconImage.enabled = false;
            iconError.SetActive(true);
        }
        
        if (Plugin.instance.soundOn.Value)
            audioSource.Play();
        
        StartCoroutine(ShowAndFadeOut());
    }

    private IEnumerator ShowAndFadeOut()
    {
        yield return new WaitForSeconds(stayDuration);

        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        float startAlpha = canvasGroup.alpha;
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, timeElapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        Destroy(gameObject);
    }
}