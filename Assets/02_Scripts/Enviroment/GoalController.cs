using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class GoalController : MonoBehaviour
{
    public Action<GoalController> HitGoal;
    public List<PlayerController> goals = new List<PlayerController>();
    [SerializeField] public PlayerColor goalColor = PlayerColor.GREEN;
    [SerializeField] private GameObject goalAnimation = null;
    [SerializeField] private TMPro.TMP_Text goalColorText = null;
    [SerializeField] private TMPro.TMP_Text goalPoints = null;
    private List<GameObject> animations = new List<GameObject>();
    bool hitted = false;

    void Awake()
    {
        UpdateUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (hitted) return;

        BallController ball = other.gameObject.GetComponent<BallController>();

        if (ball)
        {
            goals.Add(ball.LastHit);
            animations.Add(Instantiate(goalAnimation, transform.position, Quaternion.identity));
            UpdateUI();
            hitted = true;
            HitGoal?.Invoke(this);
        }
    }

    public void UpdateUI()
    {
        goalColorText.text = goalColor.ToString();
        goalPoints.text = goals.Count.ToString();
    }

    public void ResetGoal()
    {
        foreach (GameObject animation in animations)
            Destroy(animation);

        animations = new List<GameObject>();
        hitted = false;
    }

    public void ResetGoalCompletely()
    {
        ResetGoal();
        goals = new List<PlayerController>();
    }
}
