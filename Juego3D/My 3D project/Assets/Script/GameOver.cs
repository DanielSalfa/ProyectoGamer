using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Reiniciar()
    {
        int nivelActual = ScoreTraker.instance.NivelActual;
        SceneManager.LoadScene(nivelActual);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
