using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Runner.GameController;
namespace Runner.CharacterController
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        private float speed;
        [SerializeField] private Animator anim;
        public int ID;
        public Vector3 startPose;
        [SerializeField] private RawImage icon;
        private void Awake()
        {
            startPose = transform.position;
        }

        public void SetSpeedToCharacter()
        {
            speed = Random.Range(100, 200);
            float animSpeed = Mathf.Clamp(speed / 200f, 0f, 1f);
            GameManagerr.Instance.animatorController.SetFloat(anim, "runningSpeed", animSpeed);
            //anim.SetFloat("runningSpeed", animSpeed);
        }

        public void ShowIconInWinnerView()
        {
            GameManagerr.Instance.restartPage.winnerImage.texture = icon.texture;
        }

        public void StartRunning()
        {

            GameManagerr.Instance.animatorController.SetBool(anim, "runing", true);
            //anim.SetTrigger("run");
            // anim.SetBool("runing", true);
        }
        public void StopRunning()
        {
            GameManagerr.Instance.animatorController.SetBool(anim, "runing", false);
            GameManagerr.Instance.animatorController.SetTriger(anim, "stopRun");
            //anim.SetBool("runing", false);
            //anim.SetTrigger("stopRun");
        }

        public void MoveCharacterToStartPose()
        {
            transform.position = startPose;
        }
        public void Jump(float speed)
        {
            GameManagerr.Instance.animatorController.SetFloat(anim, "jumpingAnimationSpeed", speed);
            GameManagerr.Instance.animatorController.SetTriger(anim, "jump");
            // anim.SetFloat("jumpingAnimationSpeed", speed);
            // anim.SetTrigger("jump");

        }
        public void ChangeAnimatorStatus(bool status)
        {
            anim.enabled = status;
        }
    }
}