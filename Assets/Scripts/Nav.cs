using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Nav : MonoBehaviour
{
    //Ponto para o qual o personagem irá se mover
    private GameObject Point;
    //Variável NavMeshAgent Para configurar A movimentação do personagem
    private NavMeshAgent agent;
    void Start()
    {
        Vector2 but = GameObject.Find("Butler").transform.position;
        gameObject.transform.position = new Vector2(Random.Range(-13f, 13f), Random.Range(-7f, 7f));

        float distance = Vector2.Distance(gameObject.transform.position, but);

        while(distance < 5)
        {
            gameObject.transform.position = new Vector2(Random.Range(-13f, 13f), Random.Range(-7f, 7f));
            distance = Vector2.Distance(gameObject.transform.position, but);
        }
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Variaveis setadas como False para Não utilizar os eixos Y Baseado em 3 dimensões
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // Encontra o ponto Na cena
        Point = GameObject.Find("Butler");
       
    }

    
    void Update()
    {
        //Faz o personagem se locomover pelo cenario até o point
        agent.SetDestination(Point.transform.position);
    }
}
