using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;
    public static Animator anim;
    public static TextMeshProUGUI text;
    public static int Score
    {
        get => score;
        set
        {
            score = value;
            text.text = score.ToString();
            anim.SetTrigger("Grow");
        }
    }

}
