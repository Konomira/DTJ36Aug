using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image background;
    public TMP_Text scoreLabel, endScreenScoreLabel;
    public Image one,two,three, playerImage;
    public Sprite[] sprites;
    int currentSprite;
    int score;
    public void Go()
    {
        StartCoroutine(GameRoutine());
        StartCoroutine(ChangeBackgroundColor());
    }

    public void FadeBackground()
    {
        StartCoroutine(FadeInBackground());
    }

    private IEnumerator FadeInBackground()
    {
        var time = 0f;
        Color col = default;
        while(time < 1f)
        {
            col = background.color;
            col.a = Mathf.Lerp(0f, 1f, time);
            background.color = col;
            time += Time.deltaTime;
            yield return null;
        }
        col = background.color;
        col.a = 1f;
        background.color = col;
    }

    private IEnumerator ChangeBackgroundColor()
    {
        while (true)
        {
            var col = background.color;
            Color.RGBToHSV(col, out var h, out var s, out var v);

            h += Time.deltaTime * 0.2f;

            var newCol = Color.HSVToRGB(h, s, v);
            background.color = newCol;
            yield return null;
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
        one.enabled = false;
        two.enabled = false;
        three.enabled = false;
        playerImage.enabled = false;
    }

    private IEnumerator GameRoutine()
    {
        var delay = new WaitForSeconds(0.5f);
        while (true)
        {
            currentSprite = Random.Range(0, sprites.Length);
            one.enabled = false;
            two.enabled = false;
            three.enabled = false;
            playerImage.enabled = false;    
            var s = sprites[currentSprite];
            one.sprite = s;
            two.sprite = s;
            three.sprite = s;
            one.enabled = true;
            yield return delay;
            two.enabled = true;
            yield return delay;
            three.enabled = true;
            yield return delay;
            one.enabled = false;
            two.enabled = false;
            three.enabled = false;
            playerImage.enabled = true;
            if (playerImage.sprite == s)
                score += 100;
            else
                score -= 50;
            yield return delay;
        }
    }

    void Update()
    {
        scoreLabel.text = $"Score: {score}";
        endScreenScoreLabel.text = $"Score: {score}";
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerImage.sprite = sprites[0];
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerImage.sprite = sprites[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerImage.sprite = sprites[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerImage.sprite = sprites[3];
        }
    }
}