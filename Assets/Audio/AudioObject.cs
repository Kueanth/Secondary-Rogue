using UnityEngine;
using System.Collections;

public class AudioObject : MonoBehaviour
{
    public static AudioObject Instance;

    public AudioClip[] audioClips;

    public AudioSource audioSource;

    public bool isActive = true;

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

    public void Shoot()
    {
        audioSource.PlayOneShot(audioClips[3]);
    }

    public void Health()
    {
        audioSource.PlayOneShot(audioClips[4]);
    }

    public IEnumerator EnterInDungeon()
    {
        for(float i = 1f; i > 0.1f; i -= 0.1f)
        {
            if(i > 0.1f)
            {
                yield return new WaitForSeconds(0.2f);
                audioSource.volume = i;
            }

            EditMusic(1);
        }
    }

    public IEnumerator EnterInMenu()
    {
        for (float i = 1f; i > 0.1f; i -= 0.1f)
        {
            if (i > 0.1f)
            {
                yield return new WaitForSeconds(0.15f);
                audioSource.volume = i;
            }

            EditMusic(0);
        }
    }

    public void EditMusic(int clip)
    {
        audioSource.clip = audioClips[clip];
        audioSource.volume = 1;
        audioSource.Play();
    }

    public void EditMute()
    {
        if (isActive)
            audioSource.mute = true;
        else
            audioSource.mute = false;
    }

    public void Quieter()
    {
        audioSource.volume = 0.5f;
    }

    public void Louder()
    {
        audioSource.volume = 1f;
    }
}