using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float time = 0;
    public GameObject hero;    
    private Hero scriptHero;
    private Rigidbody2D rbHero;
    

    public void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = time.ToString() + " S";
        scriptHero = hero.GetComponent<Hero>();
        rbHero = hero.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(rbHero.simulated == true) 
        { ManageTimer(); }       
    }

    public void ManageTimer()
    {
        time += Time.deltaTime;
        timerText.text = Mathf.Round(time).ToString() +" S";
    }

}
