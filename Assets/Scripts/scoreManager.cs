using UnityEngine;
using TMPro;
public class scoreManager : MonoBehaviour
{
    private int scoreP1, scoreP2;
    public int MaxPoints = 2;
    public TMP_Text TxtScoreP1, TxtScoreP2, TxtResult;
    public  bool EndGame = false;
    public void AddScore(int p)
    {
        if (p == 1) scoreP1++;
        if (p == 2) scoreP2++;
        TxtScoreP1.text = scoreP1.ToString();
        TxtScoreP2.text = scoreP2.ToString();
        if (scoreP1 == MaxPoints)
        {
            TxtResult.text = "You Win!";
            EndGame = true;
        }
        if (scoreP2 == MaxPoints)
        {
            TxtResult.text = "You Loose!";
            EndGame = true;
        }
    }
    private void Update()
    {
        // Pour quitter le jeu
        if (Input.GetKeyUp(KeyCode.Escape)) Application.Quit();
    }
}
