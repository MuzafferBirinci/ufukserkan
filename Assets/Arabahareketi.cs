using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arabahareketi : MonoBehaviour
{
    bool oyunbitti = false;
    public int puan = 0;
    AudioSource audioSource;

    bool dTusunaBasildi = false;
    bool aTusunaBasildi = false;


    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
        GetComponent<Rigidbody>().velocity = new Vector3(-30, 0, 0);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey("d"))
        {
            dTusunaBasildi = true;
            
        }
        if (Input.GetKey("a"))
        {
            aTusunaBasildi = true;
            
        }
        
       

    }
    private void FixedUpdate()
    { 
        if (oyunbitti == false)
             GetComponent<Rigidbody>().AddForce(Vector3.left*140, ForceMode.Force);
        
        else if (oyunbitti == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        if(dTusunaBasildi)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 140, ForceMode.Force);
            dTusunaBasildi = false;
        }
        
        if(aTusunaBasildi)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -140, ForceMode.Force);
            aTusunaBasildi = false;
        }
        if ((GetComponent<Rigidbody>().position.x <= -185) || (GetComponent<Rigidbody>().position.z <-12) || (GetComponent<Rigidbody>().position.z >12) || (GetComponent<Rigidbody>().position.x>199))
        {
            oyunbitti = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "engel")
        {

            Invoke("restart", 1f);
            oyunbitti = true;
            audioSource.Play();
        }
        if(collision.collider.tag =="coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }
    private void restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunbitti = false;
    }



}
