using UnityEngine;
using UnityEngine.UI;

public class MusicSwiper : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip[] audioClips;

    [Header("UI References")]
    public GameObject buttonPrefab; // Префаб кнопки
    public Transform contentPanel;  // Контейнер внутри Scroll View
    public AudioSource audioSource; // Компонент, который проигрывает звук

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        foreach (AudioClip clip in audioClips)
        {
            GameObject newButton = Instantiate(buttonPrefab, contentPanel);
            newButton.GetComponentInChildren<Text>().text = clip.name;

            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                PlayClip(clip);
            });
        }
    }

    void PlayClip(AudioClip clip)
    {
        if (audioSource.clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void StopPlaying()
    {
        if (audioSource.clip != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PlayAudio()
    {
        if (audioSource.clip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
