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
            Plugin.mls.LogInfo("Achievement popup details set with icon");
        }
        else
        {
            iconImage.enabled = false;
            iconError.SetActive(true);
            Plugin.mls.LogInfo("Achievement popup details set without icon");
        }
        
        if (Plugin.instance.soundOn.Value)
            audioSource.Play();
        
        // Start the coroutine to handle stay duration and then fade out
        StartCoroutine(ShowAndFadeOut());
    }

    private IEnumerator ShowAndFadeOut()
    {
        // Wait for the stay duration before starting the fade out
        yield return new WaitForSeconds(stayDuration);

        // Start the fade out process
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