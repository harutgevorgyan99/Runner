using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        float animSpeed = Mathf.Clamp(speed/200f, 0f, 1f);
        anim.SetFloat("runningSpeed", animSpeed);
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    public void MoveCharacter()
    {
       // rb.velocity=transform.forward * speed * Time.deltaTime;
    }
    public void Jump(float speed)
    {
        anim.SetFloat("jumpingAnimationSpeed", speed);
        anim.SetTrigger("jump");
       
    }
    public void OnEnable()
    {
        enabled = true;
    }
}
