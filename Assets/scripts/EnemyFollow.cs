using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float distanciaParaSeguir = 10f;
    public float distanciaMinima = 2f;

    private NavMeshAgent navMesh;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        GameObject jugadorObj = GameObject.FindGameObjectWithTag("Player");

        if (jugadorObj != null)
        {
            player = jugadorObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador < distanciaParaSeguir && distanciaAlJugador > distanciaMinima)
        {
            navMesh.SetDestination(player.position);
        }
        else
        {
            navMesh.ResetPath();
        }
    }
}
