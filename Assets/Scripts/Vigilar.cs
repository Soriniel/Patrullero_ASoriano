using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Constructor para VIGILAR
public class Vigilar : Estado
{
    public Vigilar() : base()
    {
        Debug.Log("VIGILAR");
        nombre = ESTADO.VIGILAR; // Guardamos el nombre del estado en el que nos encontramos.
    }

    public override void Entrar()
    {
        // Le pondríamos la animación de andar, calcular los puntos por los que patrulla, etc...
        enemigoIA.agent.destination = enemigoIA.a.position;

        base.Entrar();
    }

    public override void Actualizar()
    {
        RaycastHit hit;
        Vector3 origen = enemigoIA.vision.transform.position;
        Vector3 direccion = enemigoIA.vision.transform.forward;

        // Le decimos que se vaya moviendo y patrullando...
        if (Vector3.Distance(enemigoIA.enemigo.transform.position, enemigoIA.a.transform.position) <= 3)
        {
            enemigoIA.agent.destination = enemigoIA.b.position;

        }

        if (Vector3.Distance(enemigoIA.enemigo.transform.position, enemigoIA.b.transform.position) <= 3)
        {
            enemigoIA.agent.destination = enemigoIA.a.position;

        }

        if (Physics.Raycast(origen, direccion, out hit, 10f))
        {
            Debug.Log("El rayo impactó contra: " + hit.collider.name);
        }

        if (PuedeVerJugador())
        {
            siguienteEstado = new Atacar();
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de VIGILAR a ATACAR.
        }
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de andar, detener las corrutinas, o lo que sea...
        base.Salir();
    }

    // Puede el NPC ver el jugador?
    public bool PuedeVerJugador()
    {
        // ...        
        return false; // DE MOMENTO NO
    }
}