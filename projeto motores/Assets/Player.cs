using System;
using Vector3 = UnityEngine.Vector3;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcapulo = 7;
    private bool noChão;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("star");
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!noChão && collision.gameObject.tag == "Chão")
        {
            noChão = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direcao = new UnityEngine.Vector3(x, 0, y);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && noChão)
        {
            rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
            noChão = false;
        }

        if (transform.position.y <= -10)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}