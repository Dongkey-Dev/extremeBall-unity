using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip scoreBallSound1, scoreBallSound2, playerJumpSound, playerDestroyedSound;
    static AudioSource audioSrc;

    void Start(){
        scoreBallSound1 = Resources.Load<AudioClip>("scoreBallSound1");
        scoreBallSound2 = Resources.Load<AudioClip>("scoreBallSound2");
        playerJumpSound = Resources.Load<AudioClip>("playerJumpSound");
        playerDestroyedSound = Resources.Load<AudioClip>("playerDestroyedSound");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string clip){
        switch(clip){
            case "scoreBallSound":
                // audioSrc.PlayOneShot(scoreBallSound1);
                audioSrc.PlayOneShot(scoreBallSound2);
                break;
            case "playerJumpSound":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "playerDestroyedSound":
                audioSrc.PlayOneShot(playerDestroyedSound);
                break;

        }
    }
}
