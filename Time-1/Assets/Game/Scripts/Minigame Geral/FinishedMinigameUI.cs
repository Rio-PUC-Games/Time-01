using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishedMinigameUI : MonoBehaviour
{
    public GameObject finishedMinigameUI;
    public Image progressBar;
    public TextMeshProUGUI percentage_txt;
    public TextMeshProUGUI statsGained_txt;
    public TextMeshProUGUI comments_txt;

    private RaisePlayerStats stats;

    private void Awake()
    {
        this.enabled = false;
    }

    void Start()
    {
        stats = GetComponent<RaisePlayerStats>();

        finishedMinigameUI.SetActive(true);
        StartCoroutine(LerpUI(stats.performacePercentage));
        if (stats.performacePercentage >= 1f)
        {
            comments_txt.text = "Excelente!";
            percentage_txt.text = "A+";
        }
        else if (stats.performacePercentage >= 0.8f)
        {
            comments_txt.text = "�timo!";
            percentage_txt.text = "A-";
        }
        else if (stats.performacePercentage >= 0.70f)
        {
            comments_txt.text = "Bom";
            percentage_txt.text = "B+";
        }
        else if (stats.performacePercentage >= 0.60f)
        {
            comments_txt.text = "Bom";
            percentage_txt.text = "B-";
        }
        else if (stats.performacePercentage >= 0.50f)
        {
            comments_txt.text = "Mais ou menos!";
            percentage_txt.text = "C+";
        }
        else if (stats.performacePercentage >= 0.40f)
        {
            comments_txt.text = "Mais ou menos!";
            percentage_txt.text = "C-";
        }
        else if(stats.performacePercentage >= 0.30f)
        {
            comments_txt.text = "Ruim!";
            percentage_txt.text = "D+";
        }
        else
        {
            comments_txt.text = "Ruim!";
            percentage_txt.text = "D-";
        }
        Pause.isPaused = true;
    }

   /* private void LateUpdate()
    {
        if ((Timer.timeStopped || Spawner.allWavesFinished) && !finishedUIShown)
        {
            print(stats.performacePercentage);
            finishedMinigameUI.SetActive(true);
            StartCoroutine(LerpUI(stats.performacePercentage));
            if (stats.performacePercentage >= 1f)
                comments_txt.text = comments[0];
            else if (stats.performacePercentage >= 0.8f)
                comments_txt.text = comments[1];
            else if (stats.performacePercentage >= 0.7f)
                comments_txt.text = comments[2];
            else if (stats.performacePercentage >= 0.6f)
                comments_txt.text = comments[3];
            else if (stats.performacePercentage >= 0.4f)
                comments_txt.text = comments[4];
            else
                comments_txt.text = comments[5];
            finishedUIShown = true;
        }
    }*/

    private IEnumerator LerpUI(float performanceValue)
    {
        float elapsedTime = 0;
        float waitTime = 1f;
        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            float value = Mathf.Lerp(0f, performanceValue, Mathf.SmoothStep(0.0f, 1.0f, (elapsedTime / waitTime)));
            if (stats.minigame == RaisePlayerStats.MinigameType.Minigame01)
                statsGained_txt.text = "Ataque + " + (int)(value * stats.raise);
            else if (stats.minigame == RaisePlayerStats.MinigameType.Minigame02)
                statsGained_txt.text = "Defesa + " + (int)(value * stats.raise);
            else
                statsGained_txt.text = "Velocidade + " + (int)(value * stats.raise);

            progressBar.fillAmount = value;
            yield return null;
        }
        yield return null;
    }
}
