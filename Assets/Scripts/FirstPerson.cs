using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float factorGraveda;

    //[SerializeField] private  movimientoVertical; 

    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverYRotar();
    }
    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h= 0, h=-1 h=1
        float v = Input.GetAxisRaw("Vertical");
        Vector3 movimieto = new Vector3(h, 0, v).normalized;
        float anguloRotacion = Mathf.Atan2(movimieto.x , movimieto.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        if (movimieto.magnitude > 0)
        {
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            controller.Move(movimieto * velocidadMovimiento * Time.deltaTime);
        }
        
        //AplicarGravedad();
    }



    //private void AplicarGravedad() 
    //{
    //    movimientoVertical.y += factorGravedad * Time.deltaTime;
    //    controller.Move(movimientoVertical * Time.deltaTime);
    //}

    //private void EnSuelo() 
    //{
    //    Physics.CheckSphere(pies.position, radioDetencion);
    //}
}
