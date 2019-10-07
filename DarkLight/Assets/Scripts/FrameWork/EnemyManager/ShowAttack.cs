using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAttack : MonoBehaviour {

    public GameObject AttackShow;
    public Transform Can;
    public GameObject Body;
    public GameObject Attack_Effect;
    private Color normal;
    private void Start()
    {
        normal = Body.GetComponent<Renderer>().material.color;
    }
    public void ShowAttackMsg(string showString,Color showColor)
    {
        GameObject go = GameObject.Instantiate(AttackShow, Can);
        Can.LookAt(Camera.main.transform);
        Can.transform.Rotate(new Vector3(0, 180, 0));
        Text AttackShowText = go.GetComponent<Text>();
        AttackShowText.text = String.Empty;
        AttackShowText.text = showString;
        AttackShowText.color = showColor;
        if(showColor==Color.red)
        {
            StartCoroutine("ShowBodyRed", showColor);
            Instantiate(Attack_Effect,transform.position,Quaternion.identity);
        }
        Tween t = DOTween.To(() => go.transform.localPosition, x => go.transform.localPosition = x, new Vector3(go.transform.localPosition.x, go.transform.localPosition.y + 0.5f, go.transform.localPosition.z), 0.80f);
        AttackShowText.CrossFadeAlpha(0, 0.8f, true);
        t.OnComplete(() =>
        {
            Destroy(go);
        }
        ); 
    }
    IEnumerator ShowBodyRed(Color showColor)
    {
        Body.GetComponent<Renderer>().material.color = showColor;
        yield return new WaitForSeconds(0.2f);
        Body.GetComponent<Renderer>().material.color = normal;
    }
}
