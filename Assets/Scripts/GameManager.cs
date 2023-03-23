using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject S;
    public Rigidbody2D rbHero;
    private bool freezeHero;
    public Button b_pause;
    public Button b_miniPause;
    public Button b_resume;
    public Button b_menuInSummaryLVL;
    public Button b_menu;
    public Button b_levelsRoom;
    public Button b_nextLevel;
    public GameObject summaryLevel;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        Time.timeScale = 1;
        rbHero = S.GetComponent<Rigidbody2D>();
        rbHero.simulated = freezeHero = false ;    
        
    }

    public void ActiveButton(Button button)
    {
        button.gameObject.SetActive(true);
    }

    public void DeactivateButton(Button button)
    {
        button.gameObject.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelRoom");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
        Time.timeScale = 1;
    }

    public void TakeAMiniBreak()
    {
        freezeHero = true;
        FreezeRBHero(freezeHero);
        DeactivateButton(b_miniPause);
    }
    public void FreezeRBHero(bool freezeHero)
    {
        if (freezeHero == true)
        {
            rbHero.simulated = true;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        DeactivateButton(b_pause);
        ActiveButton(b_menu);
        ActiveButton(b_resume);
    }
        
    public void RemovePause()
    {
        DeactivateButton(b_resume);
        DeactivateButton(b_menu);
        ActiveButton(b_pause);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        summaryLevel.gameObject.SetActive(false);
        rbHero.simulated = false;
        Time.timeScale = 1;        
    }

    public void levelSummary()
    {        
        Time.timeScale = 0;
        summaryLevel.SetActive(true);
    }

    public void LevelRoom()
    {
        SceneManager.LoadScene("LevelRoom");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level_1");        
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level_2");        
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level_4");        
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level_5");
        
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level_6");        
    }
    public void Level7()
    {
        SceneManager.LoadScene($"Level_7");
    }
    public void Level8()
    {
        SceneManager.LoadScene($"Level_8");
    }
    public void Level9()
    {
        SceneManager.LoadScene($"Level_9");
    }
    public void Level10()
    {
        SceneManager.LoadScene($"Level_10");
    }
    


}
