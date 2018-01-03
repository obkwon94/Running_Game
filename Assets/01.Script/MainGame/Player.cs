using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

	// Use this for initialization
	void Start ()
    {
        PlayerView.Init(this);
        ChangeState(eState.IDLE);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump(_jumpSpeed);
        }

        //가속도
        if(eState.RUN == _state)
        {
            if(_velocity.x < _maxSpeed)
            {
                _velocity.x += _addSpeed;
            }
            else
            {
                _velocity.x = _maxSpeed;
            }
        }
    }

    //캐릭터의 상태
    public enum eState
    {
        IDLE,
        RUN,
    };

    eState _state;

    //for test
    public float _maxSpeed = 15.0f;
    public float _addSpeed = 0.01f;
    public float _jumpSpeed = 10.0f;

    public void ChangeState(eState state)
    {
        _state = state;

        switch (state)
        {
            case eState.IDLE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;

            case eState.RUN:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.RunState();
                break;
        }
    }

    //Move
    Vector2 _velocity = Vector2.zero;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    public void ResetSpeed()
    {
        _velocity.x = 0.0f;
    }
}
