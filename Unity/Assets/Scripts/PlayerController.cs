using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Primero defino todas las variables.
    CharacterController characterController;

    [Header("Movimiento:")]
    public float walkSpeed = 6.5f; //Para que incremente la velocidad del personaje al andar.
    public float runSpeed = 10.0F;
    public float jumpSpeed = 12.0f;
    public float gravity = 15.0f;

    [Header("Rotacion de la camara:")]
    public Camera camera;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse; //No se pone public para que no se vea en Unity.
    //Solo queremos que se vea en unity lo que queremos que se pueda editar desde alli. 
    //Mucha atencion cuando estemos en una empresa en que poner publico y que no.

    //Para que los ejes esten en el cero cero cero (0,0,0) del mundo:
    private Vector3 move = Vector3.zero; //Vector3 por que son tres posiciones X, Y, Z. Vector3.zero para que esten en la posicion (0,0,0).

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); //Ponemos un Get pata obbtener un Componente.

    }

    // Update is called once per frame
    void Update()
    {
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation); //Para limitar la rotacion.
        camera.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0); //v_mouse negativo para que la rotación de la camara no este invertida.
        transform.Rotate(0, h_mouse, 0); //Para que rote horizontalmente.

        //Para que la gravedad afecte al personaje:
        if (characterController.isGrounded) //que solo se desplace si esta en contacto con el suelo (si no la gravedad no le afectaria).
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")); //Mover horizontal y verticalmente.

            if (Input.GetKey(KeyCode.LeftShift)) //si yo pulso la tecla Shift en el teclado, pedimos el izquierdo "Left" por que hay el izquierdo y derecho.
            {
                move = transform.TransformDirection(move) * runSpeed; //Que se mueva mas rapido cuando se pulse la tecla shift.
            }
            else
            {
                move = transform.TransformDirection(move) * walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space)) //Mirar los tipos de keyCode. Tambien se pueden reflejar numericamente.
            {
                move.y = jumpSpeed;
            }

        }

        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime); //Limitar el personaje por las colisiones.
    }
}