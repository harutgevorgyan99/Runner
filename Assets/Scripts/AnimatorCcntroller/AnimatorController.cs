using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner.AnimatorrController
{
    public class AnimatorController : MonoBehaviour
    {

        public void SetFloat(Animator anim, string name, float value)
        {
            anim.SetFloat(name, value);
        }
        public void SetBool(Animator anim, string name, bool value)
        {
            anim.SetBool(name, value);
        }
        public void SetTriger(Animator anim, string name)
        {
            anim.SetTrigger(name);
        }
    }
}