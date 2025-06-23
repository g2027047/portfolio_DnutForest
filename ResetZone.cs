using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetZone : MonoBehaviour
{
    public GameObject Combo;
    AudioSource HitaudioSource;
    public AudioClip HitSound;
    //Collision oter;

    // Start is called before the first frame update
    void Start()
    {
        HitaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "Dnut")
        {
            HitaudioSource.PlayOneShot(HitSound);
            Combo.GetComponent<Combo_Script>().ResetC_R();		//　コンボ＆ランクのリセット関数へ飛ぶ。
            Destroy(other.gameObject);
            Debug.Log("<color=red>荷台が襲撃されました</color>");
        }
    }
}
