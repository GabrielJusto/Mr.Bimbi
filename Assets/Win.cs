using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    public string sceneToLoad;

    private GameObject butler;
    private GameObject box_blue;
    private GameObject box_yellow;
    private GameObject box_red;
    private GameObject botao_azul;
    private GameObject botao_amarelo;
    private GameObject botao_vermelho;

    private void Start()
    {
        if (butler == null)
        {
            butler = GameObject.Find("Butler");
        }
        if (box_blue == null)
        {
            box_blue = GameObject.Find("Box_blue");
        }
        if (box_yellow == null)
        {
            box_yellow = GameObject.Find("Box_yellow");
        }
        if (box_red == null)
        {
            box_red = GameObject.Find("Box_red");
        }
        if (botao_azul == null)
        {
            botao_azul = GameObject.Find("botao_azul");
        }
        if (botao_amarelo == null)
        {
            botao_amarelo = GameObject.Find("botao_amarelo");
        }
        if (botao_vermelho == null)
        {
            botao_vermelho = GameObject.Find("botao_vermelho");
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Butler"))
        {
            butler.GetComponent<Renderer>().enabled = false;
            box_blue.GetComponent<Renderer>().enabled = false;
            box_yellow.GetComponent<Renderer>().enabled = false;
            box_red.GetComponent<Renderer>().enabled = false;
            botao_azul.GetComponent<Renderer>().enabled = false;
            botao_amarelo.GetComponent<Renderer>().enabled = false;
            botao_vermelho.GetComponent<Renderer>().enabled = false;

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
