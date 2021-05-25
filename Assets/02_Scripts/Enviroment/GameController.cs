using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public List<PlayerController> Players { get; private set; }
    [SerializeField] private List<Camera> cameras = new List<Camera>();
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
        Players.Add(newPlayer);
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
