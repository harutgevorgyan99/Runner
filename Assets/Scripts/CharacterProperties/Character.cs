using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Runner.Game;
using Runner.Obstacles;

namespace Runner.CharacterProperties
{
    public class Character : CharacterData
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private CapsuleCollider capsuleCollider;
        private float speed;
        [SerializeField] private Animator anim;

        public Vector3 startPose;

        private void Awake()
        {
            startPose = transform.position;
            SetSpeedToCharacter();
        }
        private void Start()
        {
           
            GameEventsManager.Instance.EndGame.AddListener(() => ChangeAnimatorStatus(false));
            GameEventsManager.Instance.RestartGame.AddListener(() => ChangeAnimatorStatus(true));
            GameEventsManager.Instance.RestartGame.AddListener(() => MoveCharacterToStartPose());
            GameEventsManager.Instance.RestartGame.AddListener(() => SetSpeedToCharacter());
            GameEventsManager.Instance.RestartGame.AddListener(() => ResetAnimatorParametersToDefault());
            GameEventsManager.Instance.RunCharacters.AddListener(() => StartRunning());
            GameEventsManager.Instance.playingCharacters.Add(this);
        }
        public void SetSpeedToCharacter()
        {
            speed = Random.Range(100, 200);
            float animSpeed = Mathf.Clamp(speed / 200f, 0f, 1f);
         
            anim.SetFloat("runningSpeed", animSpeed);
        }

        public void ShowIconInWinnerView()
        {
            GameEventsManager.Instance.restartPageUi.winnerImage.texture = icon.texture;
        }

        public void StartRunning()
        {

             anim.SetBool("runing", true);
        }
        public void StopRunning()
        {

            anim.SetBool("runing", false);
            anim.SetTrigger("stopRun");
        }

        public void MoveCharacterToStartPose()
        {   
            transform.position = startPose;
        }
        public void Jump(ObstaclesColliderTrigger obstaclesColliderTrigger)
        {
            float playerDistancFromObst = Vector3.Distance(transform.position, obstaclesColliderTrigger.jumpPositionData.transform.position);
            float speed = obstaclesColliderTrigger.jumpPositionData.normalJumpingDistance / playerDistancFromObst;
            anim.SetFloat("jumpingAnimationSpeed", speed);
            anim.SetTrigger("jump");

        }
        public void ChangeAnimatorStatus(bool status)
        {
            anim.enabled = status;
        }
        public void ResetAnimatorParametersToDefault()
        {
            anim.SetFloat("jumpingAnimationSpeed", 1);
            anim.SetBool("runing", false);
        }
    }
}