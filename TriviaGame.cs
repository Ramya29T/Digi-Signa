using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Question
{
    public Sprite image;
    public string[] answers;
    public int correctAnswerIndex; // Index of the correct answer
    public string CorrectAnswerText => answers[correctAnswerIndex]; // Text of the correct answer
}

public class TriviaGame : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    public Image questionImage;
    public Button[] answerButtons;
    public List<Question> questions;

    public GameObject currentGamePanel; // Current Game Panel
    public GameObject endGamePanel;     // End Game Panel
    public Text finalScoreText;         // Text element for final score

    private Question currentQuestion;
    private int score;
    private float timer;
    private const float maxTime = 20f;
    private List<int> usedIndexes = new List<int>();

    private void Start()
    {
        score = 0;
        timer = maxTime;
        LoadNextQuestion();
        endGamePanel.SetActive(false); // Ensure end game panel is initially hidden
    }

    private void Update()
    {
        if (currentGamePanel.activeSelf) // Run timer only if the game panel is active
        {
            timer -= Time.deltaTime;
            timerText.text = "" + Mathf.Max(timer, 0).ToString("F2");

            if (timer <= 0)
            {
                LoadNextQuestion();
            }
        }
    }

    private void LoadNextQuestion()
{
    if (questions.Count == 0 || usedIndexes.Count == questions.Count)
    {
        EndGame();
        return;
    }

    // Select a random question that hasn't been used yet
    int index;
    do
    {
        index = UnityEngine.Random.Range(0, questions.Count);
    } while (usedIndexes.Contains(index));

    usedIndexes.Add(index);
    currentQuestion = questions[index];

    // Set question image
    questionImage.sprite = currentQuestion.image;

    // Assign answer texts to buttons
    for (int i = 0; i < answerButtons.Length; i++)
    {
        Text buttonText = answerButtons[i].GetComponentInChildren<Text>();
        buttonText.text = currentQuestion.answers[i];

        // Remove all previous listeners to avoid stacking listeners
        answerButtons[i].onClick.RemoveAllListeners();

        // Add new listener for the current answer index
        int answerIndex = i;
        answerButtons[i].onClick.AddListener(() => AnswerSelected(answerIndex));
    }

    // Reset the timer for the new question
    timer = maxTime;
}

    private void ResetGame()
    {
        score = 0;
        scoreText.text = "" + score;
        usedIndexes.Clear();
        timer = maxTime;
        LoadNextQuestion();
    }

    public void RetryGame()
    {
        score = 0;
        scoreText.text = "" + score;
        usedIndexes.Clear();
        timer = maxTime;
        LoadNextQuestion();

        currentGamePanel.SetActive(true); // Enable the game panel
        endGamePanel.SetActive(false);    // Disable the end-game panel
    }

    private void AnswerSelected(int index)
{
    string selectedAnswerText = answerButtons[index].GetComponentInChildren<Text>().text;

    if (selectedAnswerText.Equals(currentQuestion.CorrectAnswerText, StringComparison.Ordinal))
    {
        score++;
        scoreText.text = "" + score;
    }

    LoadNextQuestion();
}


    private void EndGame()
    {
        currentGamePanel.SetActive(false); // Disable the current game panel
        endGamePanel.SetActive(true);      // Enable the end-game panel
        finalScoreText.text = "" + score; // Display the final score
    }
}
