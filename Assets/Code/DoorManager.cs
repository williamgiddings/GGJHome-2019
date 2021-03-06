﻿using UnityEngine;

namespace Home
{
    public enum EnumState
    {
        Open,
        Close
    }
    public class DoorManager : MonoBehaviour
    {
        private Animator m_Animator;
        private EnumState m_State;

        public GameObject GOAnimator;
        public bool Enabled;
        public string Name;

        void Start()
        {
            Debug.Assert(!string.IsNullOrEmpty(Name), "Name is null or empty, are you sure this is interactive?");
            Debug.Assert(!string.IsNullOrEmpty(Name), "Name is null or empty, are you sure this is interactive?");
            Debug.Assert(GOAnimator != null, "Animator is null!");

            m_Animator = GOAnimator.GetComponent<Animator>();
            m_State = EnumState.Close;
        }

        public void PlayAnimation()
        {
            if (Enabled)
            {
                m_Animator.Play("Open", -1);
                m_State = EnumState.Open;
            }
        }

        public string GetName()
        {
            return m_State == EnumState.Close && Enabled ? "Open Door" : "Door";
        }
    }
}
