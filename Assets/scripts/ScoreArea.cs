using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public GameManager gameManager;
    public int agentID;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.EndEpisode(agentID);
    }
}

//conda info -e
//conda activate ml
//cd C:\unity\ml - agents - release_10\config
//mlagents-learn ./sample/SelfPlayEx.yaml --run-id=SelfPlayEx-ppo-1
//mlagents-learn ./sample/SelfPlayEx.yaml --run-id=SelfPlayEx-ppo-1 --resume
//config/results/selfPlayEx-ppo-1/SelfPlayEx.onnx
//mlagents-learn ./sample/SelfPlayEx.yaml --run-id=AImodel --resume