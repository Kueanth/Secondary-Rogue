using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public static AudioObject Instance;

    public AudioClip[] audioClips;

    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            audioSource = GetComponent<AudioSource>();

            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;

            audioSource.clip = audioClips[0];

            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Click()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }
}