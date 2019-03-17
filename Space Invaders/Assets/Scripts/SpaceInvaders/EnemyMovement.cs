using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Movement variables
    public static bool goLeft = false;    //Static para que sea accesible desde el collider del enemigo
    public static bool goDown = false;
    public int distance = 10;
    public float counter = 0.0f;
    public float frecuency;

    //State variables
    public bool is_boss = false;


    //Auxiliar variables
    Vector3 temp;       //Usado para modificar el valor de transform.position ya que es un Vector3 y se pasa por copia.

	void Start ()
	{
		temp = transform.position;
        goLeft = true;
	}

    void Update()
    {
        frecuency = Database.enemy_horizontalMovementFrecuency;     //Funciona mal al matar un enemigo.

        if (!is_boss)                                               //Si no es un jefe
        {
            if (goLeft)                                             //Si va hacia la izquierda
            {
                if (counter >= frecuency)                           //Cuando el contador llegue al valor de frecuency
                {
                    temp.x -= distance * Time.deltaTime;            //Se mueve a la izquierda
                    counter = 0.0f;                                 //Resetea el contador
                }
                else
                {
                    counter++;
                }
            }
            else                                                    //Si va hacia la derecha
            {
                if (counter >= frecuency)                           //Lo mismo pero pal otro lado
                {
                    temp.x += distance * Time.deltaTime;
                    counter = 0.0f;
                }
                else
                {
                    counter++;
                }
            }

            if (goDown)                                             //Si se activa la señal goDown
            {
                temp.y -= distance * 2 * Time.deltaTime;            //Se baja una fila
                goDown = false;                                     //Se resetea su valor
            }
        }

        else{                                                       //Si es un jefe
            temp.x -= distance / 4 * Time.deltaTime;
        }

        transform.position = temp;                                  //En cualquier caso, actualizar el valor de transform.position al nuevo calculado
    }

}
