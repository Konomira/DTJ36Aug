using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Animator animator;
    public AudioSource menu, game, clapping;
    public PlayerController playerController;
    bool started;

    private void Update()
    {
        if(started && !game.isPlaying)
        {
            started = false;
            animator.SetTrigger("EndGame");
            playerController.Stop();
            clapping.Play();
        }
    }

    public void FadeInBackground()
    {
        playerController.FadeBackground();
    }
    public void PlayGameMusic()
    {
        started = true;
        game.Play();
        playerController.Go();
    }

    public void StopMenuMusic()
    {
        StartCoroutine(LowerVolume(menu));
    }

    private IEnumerator LowerVolume(AudioSource source)
    {
        while(source.volume > 0)
        {
            source.volume -= Time.deltaTime;
            yield return null;
        }

        source.Stop();
    }
}
