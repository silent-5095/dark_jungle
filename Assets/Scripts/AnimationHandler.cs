using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
        [SerializeField] private Animator anime;

    //    private void OnCollisionEnter(Collision collision)
    //    {
    //        anime.SetBool("idle2",true);
    //    }
    public void SetAnimation(string state,bool condition)
    {
        anime.SetBool(state,condition);
    }
}
