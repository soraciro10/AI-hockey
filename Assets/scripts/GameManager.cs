using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Agent[] agents;
    public GameObject ball;
    public Text red;
    public Text blue;
    int scoreB;
    int scoreR;

    void Start()
    {
        Reset();
        scoreB = 0;
        scoreR = 0;
    }
    private void Update()
    {
        blue.text = scoreB.ToString();
        red.text = scoreR.ToString();
    }


    public void Reset()
    {
        agents[0].gameObject.transform.localPosition = new Vector3(0.0f, 0.2f, -6.0f);
        agents[1].gameObject.transform.localPosition = new Vector3(0.0f, 0.2f, 6.0f);

        float speed = 13.0f;
        ball.transform.localPosition = new Vector3(0.0f, 0.25f, 0.0f);
        float radius = Random.Range(45f,135f) * Mathf.PI / 180.0f ;
        Vector3 force = new Vector3(Mathf.Cos(radius) * speed, 0.0f, Mathf.Sin(radius) * speed);
        if (Random.value < 0.5f) force.z = -force.z;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = force;
    }
   public void EndEpisode(int agentId)
   {
        if (agentId == 0)
        {
            agents[0].AddReward(1.0f);
            agents[1].AddReward(-1.0f);
            scoreB += 1;
        }
        else if (agentId == 1)
        {
            agents[0].AddReward(-1.0f);
            agents[1].AddReward(1.0f);
            scoreR += 1;
        }
        agents[0].EndEpisode();
        agents[1].EndEpisode();
        Reset();
   }
}
