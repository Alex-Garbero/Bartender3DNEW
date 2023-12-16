using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] CustomerManagement script;
    public int correctScore;
    public int incorrectScore;
    public TextMeshProUGUI cScoreUI;
    public TextMeshProUGUI iScoreUI;

    private bool gameEnded = false; // Flag to track if the game has already ended

    void Update()
    {
        // If the game has already ended, don't continue checking
        if (gameEnded)
            return;

        correctScore = script.correctOrders;
        incorrectScore = script.incorrectOrders;

        cScoreUI.text = "Correct Drinks: " + correctScore.ToString();
        iScoreUI.text = "Incorrect Drinks: " + incorrectScore.ToString();

        // Check for win or loss conditions
        if (correctScore == 3)
        {
            gameEnded = true; // Set the flag to true to indicate that the game has ended
        }
        else if (incorrectScore == 5)
        {
            gameEnded = true; // Set the flag to true to indicate that the game has ended
        }
    }
}

