using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class GameController : MonoBehaviour
{
    public List<PlayerController> Players { get; private set; }
    [SerializeField] private List<Camera> cameras = new List<Camera>();
    [SerializeField] private List<CinemachineFreeLook> cms = new List<CinemachineFreeLook>();
    [SerializeField] private List<GoalController> goals = new List<GoalController>();
    [SerializeField] private Camera cam = null;
    [SerializeField] private BallController ball = null;
    [SerializeField] private float resetTime = 3f;

    void Awake()
    {
        Players = new List<PlayerController>();
        foreach (GoalController goal in goals)
        {
            goal.HitGoal += Goal;
        }
    }
    public void OnPlayerJoined(PlayerInput _newPlayerInput)
    {
        PlayerController newPlayer = _newPlayerInput.gameObject.GetComponent<PlayerController>();
        newPlayer.cam = cameras[Players.Count];
        newPlayer.cmCam = cms[Players.Count];
        cms[Players.Count].Follow = newPlayer.transform;
        cms[Players.Count].LookAt = newPlayer.transform;
        Players.Add(newPlayer);

        // _newPlayerInput.camera.cullingMask = LayerMask.NameToLayer("Player" + Player.Count);


    }

    void Goal(GoalController _goalController)
    {
        StartCoroutine(ResetAfterGoal());
    }

    IEnumerator ResetAfterGoal()
    {
        yield return new WaitForSeconds(resetTime);
        foreach (GoalController goal in goals)
            goal.ResetGoal();

        ball.ResetBall();
    }
}
