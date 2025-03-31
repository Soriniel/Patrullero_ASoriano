using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class EnemigoIA: MonoBehaviour
{
    Estado FSM;
    public Transform a;
    public Transform b;
    public Transform c;
    public GameObject enemigo;
    public NavMeshAgent agent;
    public GameObject vision;
    public int fuerzaDisparar = 50;
    public GameObject bala;
    public GameObject jugador;

    void Start()
    {
        enemigo = GameObject.Find("PATRULLERO");
        FSM = new Vigilar(this); // CREAMOS EL ESTADO INICIAL DEL NPC
        FSM.inicializarVariables(this);
    }

    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }
    public void empezarDisparar()
    {
        StartCoroutine("disparando");
    }

    public void pararDisparar()
    {
        StopCoroutine("disparando");
    }

    public IEnumerator disparando()
    {
        while (true)
        {
            Vector3 direccionJugador = (jugador.transform.position - enemigo.transform.position).normalized;
            Quaternion rotacion = Quaternion.LookRotation(direccionJugador);
            GameObject balaInstanciada = Instantiate(bala, vision.transform.position, rotacion);
            balaInstanciada.GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaDisparar , ForceMode.Impulse);

            yield return new WaitForSeconds(2);
        }

        yield return null;
    }

}