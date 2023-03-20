using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] public float speed;
    private float _currentHealth;
    private float timeEnter;
    public GameObject cameraWithGM;
    private GameManager _gameManager;
    public Slider slider;
    private HealthBar _healthBar;
    public bool activeHero;
    public Rigidbody2D _rb;

    private void Awake()
    {
        _gameManager = cameraWithGM.GetComponent<GameManager>();
        _healthBar = slider.GetComponent<HealthBar>();
        _rb = GetComponent<Rigidbody2D>();
        _currentHealth = _maxHealth;
        activeHero = true;    
    }
    

    public void Update()
    {
        HealthOfHero();
    }

    public void FixedUpdate()
    {
        MoveOfHero();
    }

    private void HealthOfHero()
    {
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);

        if (_currentHealth <= 0)
        {
            activeHero = false;
            Destroy(this.gameObject);
            _gameManager.ResetScene();
        }
    }

    private void MoveOfHero()
    {

        float xAxis = Input.GetAxis("Horizontal") + Input.acceleration.x;
        float yAxis = Input.GetAxis("Vertical") + Input.acceleration.y; ;
        /*float xAxis = Input.acceleration.x;
        float yAxis = Input.acceleration.y;*/
        /*Vector2 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime; ;
        transform.position = pos;*/

        _rb.velocity = new Vector3(xAxis * speed, yAxis * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Hole")
        {
            _gameManager.levelSummary();
            this.gameObject.SetActive(false);
            activeHero = false;

        }
        if (other.tag == "Enemy")
        {
            _currentHealth -= 1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        timeEnter = Time.time;
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy" && (timeEnter + 0.3f) > Time.time)
        {
            _currentHealth -= 1f * Time.deltaTime;
        }
    }




}
