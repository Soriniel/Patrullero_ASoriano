using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Atacar : Estado
{
    public Atacar(EnemigoIA enemigo) : base()
    {
        Debug.Log("ATACAR");
        nombre = ESTADO.ATACAR; // Guardamos el nombre del estado en el que nos encontramos.
        inicializarVariables(enemigo);

    }

    public override void Entrar()
    {
        // Le pondríamos la animación de disparar, o lo que sea...
        enemigoIA.empezarDisparar();
        base.Entrar();
    }

    public override void Actualizar()
    {
        Vector3 direction = enemigoIA.jugador.transform.position - enemigoIA.enemigo.transform.position;
        enemigoIA.enemigo.transform.position += direction.normalized * 4f * Time.deltaTime;
        enemigoIA.transform.LookAt(enemigoIA.c);

        if (!PuedeAtacar())
        {
            enemigoIA.pararDisparar();
            siguienteEstado = new Vigilar(enemigoIA); // Si el NPC no puede atacar al jugador, lo ponemos a vigilar (por ejemplo).
            faseActual = EVENTO.SALIR; // Cambiamos de FASE ya que pasamos de ATACAR a VIGILAR.
        }
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de disparar, detener las corrutinas, o lo que sea...
        base.Salir();
    }


    public bool PuedeAtacar()
    {
        if (Vector3.Distance(enemigoIA.enemigo.transform.position, enemigoIA.jugador.transform.position) <= 10)
        {

            return true;
        }

        return false; // El NPC NO ESTÁ lo suficientemente cerca para atacar al jugador.
    }
}