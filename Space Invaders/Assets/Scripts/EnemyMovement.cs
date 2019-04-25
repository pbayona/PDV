using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    
    //Movement variables
    public static bool goUp = false;    //Static para que sea accesible desde el collider del enemigo
    public static bool goLeft = false;
    public int distance = 16;
    public float counter = 0.0f;
    public float frecuency;

    //Auxiliar variables
    Vector3 temp;       //Usado para modificar el valor de transform.position ya que es un Vector3 y se pasa por copia.

	void Start ()
	{
		temp = transform.position;
        goUp = true;
	}

    void Update()
    {
        frecuency = Database.getHorizontalMovementFrecuency();     //Funciona mal al matar un enemigo.

            if (goUp)                                             //Si va hacia la izquierda
            {
                if (counter >= frecuency)                           //Cuando el contador llegue al valor de frecuency
                {
                    temp.y += distance * Time.deltaTime;            //Se mueve a la izquierda
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
                    temp.y -= distance * Time.deltaTime;
                    counter = 0.0f;
                }
                else
                {
                    counter++;
                }
            }

            if (goLeft)                                             //Si se activa la señal goDown
            {
                temp.x -= distance * 2 * Time.deltaTime;            //Se baja una fila
                goLeft = false;                                     //Se resetea su valor
            }
        
        transform.position = temp;                                  //En cualquier caso, actualizar el valor de transform.position al nuevo calculado
    }

}
