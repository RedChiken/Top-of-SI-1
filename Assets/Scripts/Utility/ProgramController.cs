﻿using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Diagnostics;
using System.Collections;

public class ProgramController : MonoBehaviour
{
    public void QuitProgram()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Process.GetCurrentProcess().Kill();
#endif
    }
}