using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] CustomerManagement script;
    public int correctScore;
    public int incorrectScore;
    public TextMeshProUGUI cScoreUI;
    public TextMeshProUGUI iScoreUI;
    

    private bool gameEnded = false; // Flag to track if the game has already ended

    public void Awake()
    {
        script = GameObject.Find("Customer").GetComponent<CustomerManagement>();
    }
    void Update()
    {
        // If the game has already ended, don't continue checking

        correctScore = script.correctOrders;
        incorrectScore = script.incorrectOrders;

        cScoreUI.text = "Correct Drinks: " + correctScore.ToString();
        iScoreUI.text = "Incorrect Drinks: " + incorrectScore.ToString();

        // Check for win or loss conditions
        if (correctScore >= 5)
        {
            SceneManager.LoadSceneAsync(2); // Set the flag to true to indicate that the game has ended
        }
        else if (incorrectScore >= 3)
        {
            SceneManager.LoadSceneAsync(3); // Set the flag to true to indicate that the game has ended
        }
    }
}

