using UnityEngine;
using UnityEngine.UI;

public class AudioC : MonoBehaviour
{
    public AudioSource music;
    public AudioSource effects;
    public AudioClip click;
    public AudioClip moveSound;
    public Toggle m;
    public Toggle e;
    public AudioClip[] sounds;
    public AudioClip win;
    public AudioClip bosterActive;
    public AudioClip bigWin;


    public void Click()
    {
        effects.PlayOneShot(click);
    }
    public void MoveSound()
    {
        effects.PlayOneShot(moveSound);
    }
    public void FixedUpdate()
    {
        if (m.isOn)
        {
            music.volume = 1;
        }
        else
        {
            music.volume = 0;
        }
        if (e.isOn)
        {
            effects.volume = 1;
        }
        else
        {
            effects.volume = 0;
        }
    }
    
}
