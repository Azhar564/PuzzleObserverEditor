using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [System.Serializable]
    public class Puzzle
    {
        [SerializeField] private SwitchTrigger _switch;
        [SerializeReference] private List<PuzzleObserver> puzzleObservers = new List<PuzzleObserver>();

        public void Initialize()
        {
            foreach (PuzzleObserver observer in puzzleObservers)
            {
                _switch.AddObserver(observer);
                observer.onDestroy += () =>
                {
                    _switch.RemoveObserver(observer);
                };
            }
        }
#if UNITY_EDITOR
        public void DrawLine()
        {
            if (_switch)
            {
                Gizmos.color = Color.red;
                foreach (PuzzleObserver observer in puzzleObservers)
                {
                    Gizmos.DrawLine(_switch.transform.position, observer.transform.position);
                }
            }
        }
#endif
    }

    public List<Puzzle> puzzles = new List<Puzzle>();

    private void Start()
    {
        foreach (Puzzle puzzle in puzzles)
        {
            puzzle.Initialize();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        foreach (Puzzle puzzle in puzzles)
        {
            puzzle.DrawLine();
        }
    }
#endif
}