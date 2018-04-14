using System.Collections;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [Header("Checkpoint Attributes")]
    public Transform[] checkpoints;

    private Vector2[] checkpointPositions;

    [Space(10)]
    public Vector2 currentCheckpoint;
    public Vector2 nextCheckpoint;

    [Space(10)]
    public int checkpointIndex;
    public int nextCheckpointIndex;

    [Header("Target Attributes")]
    public Transform targetTransform;

    private void Start()
    {
        CheckpointsSetup();
    }

    private void Update()
    {
        ManageCheckpoints();
    }

    private void CheckpointsSetup()
    {
        ReadCheckpointData();

        checkpointIndex = 0;
        nextCheckpointIndex = 1;

        currentCheckpoint = checkpointPositions[checkpointIndex];
        nextCheckpoint = checkpointPositions[nextCheckpointIndex];
    }

    private void ManageCheckpoints()
    {
        if (currentCheckpoint != null && nextCheckpoint != null)
        {
            float nextCheckpointAngle = ReturnCheckpointDirection(nextCheckpoint);

            if (nextCheckpointAngle > 0)
            {
                Debug.Log("Moving to next Checkpoint! :: " + nextCheckpointAngle);

                MoveToNextCheckpoint();
            }
        }
    }

    private void ReadCheckpointData()
    {
        checkpointPositions = new Vector2[checkpoints.Length];

        for (int i = 0; i < checkpointPositions.Length; i++)
        {
            checkpointPositions[i] = checkpoints[i].position;
        }
    }

    private void MoveToNextCheckpoint()
    {
        checkpointIndex++;
        
        if (checkpointIndex < checkpointPositions.Length - 1)
        {
            currentCheckpoint = checkpointPositions[checkpointIndex];

            nextCheckpointIndex = (nextCheckpointIndex + 1);

            if (nextCheckpointIndex < checkpointPositions.Length - 1)
            {
                nextCheckpoint = checkpointPositions[nextCheckpointIndex];
            }
            else
            {
                nextCheckpointIndex = checkpointPositions.Length - 1;

                nextCheckpoint = checkpointPositions[nextCheckpointIndex];
            }
        }
        else
        {
            checkpointIndex = checkpointPositions.Length - 1;
            nextCheckpointIndex = checkpointIndex;

            currentCheckpoint = checkpointPositions[checkpointIndex];
            nextCheckpoint = checkpointPositions[nextCheckpointIndex];
        }
    }

    private float ReturnCheckpointDirection(Vector2 targetCheckpoint)
    {
        Vector2 interceptVector = targetCheckpoint - (Vector2)targetTransform.position;

        float checkpointDirection = Vector2.Dot(targetCheckpoint, interceptVector);

        return checkpointDirection;
    }
}
