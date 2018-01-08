using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

	// Use this for initialization
	void Start ()
    {
        //_distance = 0.0f;
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
            UpdateDistance();

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

            UpdateSpeedByWeight();
         
        }
    }

    void UpdateDistance()
    {
        float deltaDistance = _velocity.x * Time.deltaTime;
        _distance += deltaDistance;

        if(_maxDistance <= _distance)
        {
            ChangeState(eState.COMPLETE);
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

    void UpdateSpeedByWeight()
    {
        if(100.0f < _currentWeight)
        {
            _maxSpeed = 12.0f;
        }
        else if (90.0f < _currentWeight)
        {
            _maxSpeed = 14.0f;
        }
        else if (80.0f < _currentWeight)
        {
            _maxSpeed = 16.0f;
        }
        else if (70.0f < _currentWeight)
        {
            _maxSpeed = 18.0f;
        }
        else if (60.0f < _currentWeight)
        {
            _maxSpeed = 20.0f;
        }
    }

    //캐릭터의 상태
    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
        COMPLETE,
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
    float _startWeight = 90.0f;
    float _decreaseWeight = 0.01f;
    float _currentWeight = 0.0f;
    float _goalWeight = 70.0f;

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
    public float GetGoalWeight()
    {
        return _goalWeight;
    }

    public void AddWeight(float addWeight)
    {
        _currentWeight += addWeight;

        if (_maxWeight < _currentWeight)
            _currentHP = _maxWeight;
        
        if (_currentWeight < _minWeight)
            _currentHP = _minWeight;
    }

    //Speed
    float _maxSpeed = 20.0f;
    float _addSpeed = 0.08f;
    float _jumpSpeed = 20.0f;

    public float GetMaxSpeed()
    {
        return _maxSpeed;
    }

    public float GetCurrentSpeed()
    {
        return _velocity.x;
    }

    //Distance
    float _maxDistance = 1000.0f;
    float _distance = 0.0f;

    public float GetMaxDistance()
    {
        return _maxDistance;
    }

    public float GetCurrentDistance()
    {
        return _distance;
    }

    //State
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

            case eState.COMPLETE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
        }
    }

    public bool IsComplete()
    {
        if (eState.COMPLETE == _state)
            return true;

        return false;
    }

    public bool IsSuccess()
    {
        float deltaWeight = _goalWeight - _currentWeight;
        float deltaWeightOffset = Mathf.Abs(deltaWeight);

        if (deltaWeightOffset < 3.0f)
            return true;

        return false;
    }

    public bool IsDead()
    {
        if (eState.DEATH == _state)
            return true;

        return false;
    }
    
    public bool CanDoubleJump()
    {
        if (MainGameManager.Instance.GetPlayer().GetCurrentWeight() < 100.0f)
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
