using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private float score;
    public GameObject score_text;
    IEnumerator Start()
    {
        while (true)
        {
            score_text.GetComponent<Text>().text = score.ToString();
            yield return new WaitForSeconds(.5f);
        }
    }
    public void add_score(float score_to_add)
    {
        score += score_to_add;
    }
}
