using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField, SelectBGM] string a;
    [SerializeField, SelectBGM] string b;
    void Start()
    {
        
    }
    public void ButaanA()
    {
        AudioManeger.Instance.PlayBgm(a);
    }
    public void ButaanB()
    {
        AudioManeger.Instance.PlayBgm(b);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
