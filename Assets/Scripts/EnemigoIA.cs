using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class EnemigoIA: MonoBehaviour
{
    Estado FSM;
    public Transform a;
    public Transform b;
    public GameObject enemigo;
    public NavMeshAgent agent;
    public GameObject vision;

    void Start()
    {
        enemigo = GameObject.Find("PATRULLERO");
        FSM = new Vigilar(); // CREAMOS EL ESTADO INICIAL DEL NPC
        FSM.inicializarVariables(this);
    }

    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }
}