using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreTraker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static ScoreTraker instance;

    public Corazones vida_canvas;

    private int _vida = 3;
    public int vida
    {
        get { return _vida; }
        set
        {
            _vida = value;
            vida_canvas.CambioVida(_vida);

            if (_vida <= 0)
            {
                ScoreTraker.instance.NivelActual = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(5);
            }
        }
    }

    private int nivelActual = 1; 

    public int NivelActual
    {
        get { return nivelActual; }
        set { nivelActual = value; }
    }

    public int score = 0;

    void Start()
    {
        UpdateScoreText();
        vida_canvas = FindObjectOfType<Corazones>();
    }

    void Awake()
    {
        instance = this;

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        if (scoreText != null)
        {
            UpdateScoreText();
        }
    }

    void Update()
    {
        vida_canvas.CambioVida(vida);
    }

    public void addScore(int amount)
    {
        score = score + amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ReceiveDamage(int damageAmount)
    {
        vida -= damageAmount;
    }

    public void RecuperarVida(int cantidadDeVidas)
    {
        if (vida < 3)
        {
            vida += cantidadDeVidas;
            if (vida > 3)
            {
                vida = 3;  
            }
        }
    }
}









