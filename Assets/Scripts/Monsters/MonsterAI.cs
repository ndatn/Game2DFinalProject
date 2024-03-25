using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirectionFloat = 2f;
    private enum State
    {
        Roaming
    }
    private State state;
    private MonsterPathFinding monsterPathFinding;
    private void Awake()
    {
        monsterPathFinding = GetComponent<MonsterPathFinding>();
        state = State.Roaming;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPos = GetRoamingPos();
            monsterPathFinding.MoveTo(roamPos);
            yield return new WaitForSeconds(roamChangeDirectionFloat);
        }
    }
    private Vector2 GetRoamingPos()
    {
        return new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)).normalized;
    }
}
