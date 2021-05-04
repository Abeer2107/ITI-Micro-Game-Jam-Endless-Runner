using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    //Clips
    [SerializeField] AudioClip MainMenuClip;
    [SerializeField] AudioClip GameplayClip;

    private void OnEnable()
    {
        UIManager.GameStarted += PlayGameplay;
    }
    private void OnDisable()
    {
        UIManager.GameStarted -= PlayGameplay;
    }

    static AudioManager instance = null;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayMainMenu();
    }

    public void PlayMainMenu()
    { //Main music
        GetComponent<AudioSource>().clip = MainMenuClip;
        GetComponent<AudioSource>().Play();
    }

    public void PlayGameplay()
    { //gameplay music
        GetComponent<AudioSource>().clip = GameplayClip;
        GetComponent<AudioSource>().Play();
    }

}
