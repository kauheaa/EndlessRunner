using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject spawner;
    public GameObject player;
    public GameObject cows;
    private GameObject[] gems;

    public Component[] scriptsInCows;
    public Instantiate spawn;

    public Vector3 playerPos;

    public Text scoreDisplay;
    public Text finalScoreDisplay;
    public Text highscoreDisplay;


    public int score;
    public int highscore;
    public int restart;
    public float ultimateSpeed = 0f;

    public GameObject gameOverScreen;
    public GameObject startMenuScreen;

    public void StartGame()
    {
        startMenuScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        ResetCows();
        player.transform.position = playerPos;
        player.SetActive(true);
        spawner.SetActive(true);
        spawn.StartSpawning();
        ultimateSpeed = 2;
        score = 0;
        scoreDisplay.text = score.ToString();
    }

    public void ResetCows()
    {
        scriptsInCows = cows.GetComponentsInChildren<PositionLevelObjects>();
        foreach (PositionLevelObjects cowScript in scriptsInCows)
        {
            cowScript.ResetCows();
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        spawner.SetActive(false);
        gameOverScreen.SetActive(true);
        finalScoreDisplay.text = score.ToString();
        highscoreDisplay.text = highscore.ToString();

        gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach(GameObject gem in gems)
        {
            Destroy(gem);
        }

    }

    public void OpenMainMenu()
    {
        gameOverScreen.SetActive(false);
        startMenuScreen.SetActive(true);
    }

    public void scoreUpdate()
    {
        score ++;
        ultimateSpeed += 0.1f;
        Debug.Log("score +1");
        scoreDisplay.text = score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        highscore = PlayerPrefs.GetInt("highscore", 0);

    }

    // Start is called before the first frame update
    private void Start()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        spawn = spawner.GetComponent<Instantiate>();
        player.SetActive(false);
        spawner.SetActive(false);
        ultimateSpeed = 0;
        score = 0;
        startMenuScreen.SetActive(true);
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
