//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio Sánchez
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivore : Character
{
    
    /// <summary>
    /// Los agentes tienes una serie de variables
    /// que dependen del tipo de dinosaurio que son.
    /// Este script las almacena.
    /// </summary>
    void Start()
    {
        foodtype = 1;
        sueñomod = 1;
        tasacansancion = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
