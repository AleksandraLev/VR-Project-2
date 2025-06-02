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
    public GameObject buttonPlay;
    public GameObject buttonStop;
    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        buttonPlay.GetComponent<Button>().onClick.AddListener(PlayAudio);
        buttonStop.GetComponent<Button>().onClick.AddListener(StopPlaying);
        foreach (AudioClip clip in audioClips)
        {
            GameObject newButton = Instantiate(buttonPrefab, contentPanel);
            newButton.GetComponentInChildren<Text>().text = clip.name;

            AudioClip currentClip = clip;
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                StopPlaying();
                audioSource.clip = currentClip;
                PlayAudio();
            });
        }
    }
    

    public void StopPlaying()
    {
        if (audioSource.clip != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        buttonPlay.SetActive(true);
        buttonStop.SetActive(false);
    }

    public void PlayAudio()
    {
        if (audioSource.clip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        buttonStop.SetActive(true);
        buttonPlay.SetActive(false);
    }
}
