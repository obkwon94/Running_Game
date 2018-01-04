using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

	// Use this for initialization
	void Start ()
    {
        _currentWeight = _startWeight;
        _currentHP = _maxHP;

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

        if(eState.RUN == _state)
        {
            //가속도
            if (_velocity.x < _maxSpeed)
            {
                _velocity.x += _addSpeed;
            }
            else
            {
                _velocity.x = _maxSpeed;
            }

            //Weight
            UpdateWeight();

            //HP
            UpdateHP();
         
        }
    }

    void UpdateWeight()
    {
        _currentWeight -= _decreaseWeight;
        if(_currentWeight < _minWeight)
        {
            _currentWeight = _minWeight;
        }
        if (_maxWeight < _currentWeight)
        {
            _currentWeight = _maxWeight;
        }
    }

    void UpdateHP()
    {
        _currentHP -= _decreaseHP;
        if(_currentHP< 0)
        {
            _currentHP = 0;

            ChangeState(eState.DEATH);
        }
        Debug.Log("HP" + _currentHP);
    }

    //캐릭터의 상태
    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
    };

    eState _state = eState.IDLE;

    //HP
    float _maxHP = 100.0f;
    float _decreaseHP = 0.1f;
    float _currentHP = 0.0f;
        
    public float GetMaxHP()
    {
        return _maxHP;
    }
    public float GetCurrentHP()
    {
        return _currentHP;
    }

    public void IncreaseHP(float addHP)
    {
        _currentHP += addHP;
        if(_maxHP < _currentHP)
        {
            _currentHP = _maxHP;
        }
    }

    //Weight
    float _maxWeight = 140.0f;
    float _minWeight = 50.0f;
    float _startWeight = 100.0f;
    float _decreaseWeight = 0.01f;
    float _currentWeight = 0.0f;

    public float GetMaxWeight()
    {
        return _maxWeight;
    }
    public float GetMinWeight()
    {
        return _minWeight;
    }
    public float GetCurrentWeight()
    {
        return _currentWeight;
    }

    public void AddWeight(float addWeight)
    {
        _currentWeight += addWeight;

        if (_maxWeight < _currentWeight)
            _currentHP = _maxWeight;
        
        if (_currentWeight < _minWeight)
            _currentHP = _minWeight;
    }

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

            case eState.DEATH:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
        }
    }

    public bool IsDead()
    {
        if (eState.DEATH == _state)
            return true;

        return false;
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
