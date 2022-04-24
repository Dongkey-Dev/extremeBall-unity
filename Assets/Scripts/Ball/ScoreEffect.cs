using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    public ParticleSystem scoreEffect;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            Instantiate(scoreEffect, this.transform.position, this.transform.rotation);
            //Debug.Log(this.transform.position);
        }
    }
    void PlayEffect()
    {
        scoreEffect.Play();
    }
}
