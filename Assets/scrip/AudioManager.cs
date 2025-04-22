using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip SoundMoney;
    [SerializeField] private Player player;

    private void OnEnable()
    {
        player.RecoletMoney += ActivarSoundMoney;

        
    }

    private void OnDisable()
    {
        player.RecoletMoney -= ActivarSoundMoney;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ActivarSoundMoney()
    {
        if (m_AudioSource != null && SoundMoney != null)
        {
            // Reproduce el clip una sola vez sin interferir con otros sonidos
            m_AudioSource.PlayOneShot(SoundMoney);
        }
        else
        {
            Debug.LogWarning("AudioSource o SoundMoney no están asignados en AudioManager.");
        }
    }


}
