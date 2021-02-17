using System;
using UnityEngine;

namespace Scenes
{
    public class DIcetest : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody.angularVelocity = new Vector3(10, 10, 5);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _rigidbody.useGravity = true;
                _rigidbody.velocity = Vector3.left;
            }

            CheckSpot();
        }
        
        
        [SerializeField]
        private Transform[] _diceSpots;
        private void CheckSpot()
        {
            if (!_rigidbody.IsSleeping())
                return;
            var topIndex = 0;
            var topValue = _diceSpots[0].transform.position.y;
            for (var i = 1; i < _diceSpots.Length; ++i)
            {
                if (_diceSpots[i].transform.position.y < topValue)
                    continue;
                topValue = _diceSpots[i].transform.position.y;
                topIndex = i;
            }
            Debug.Log(topIndex + 1);
        }
    }
    
    
}