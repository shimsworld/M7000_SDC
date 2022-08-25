Public Class CPauseControl

    Public PauseState As ePAUSESTATe
    Public HomePauseState As ePAUSEHomming
    Public EQPState As eEQPState
    ' Dim trdCheck As Thread

    Public Event evPaused()
    Public Event evReleased()


#Region "Enum"
    Public Enum ePAUSEHomming
        eNotUse
        eHome
    End Enum
        Public Enum ePAUSESTATe
            eNotUse
            eRequest
        ePaused
    End Enum

    Public Enum eEQPState
        eRun
        eStop
    End Enum
#End Region

        Public Sub New()
        PauseState = ePAUSESTATe.eNotUse
        HomePauseState = ePAUSEHomming.eNotUse
        End Sub
    Public Sub EQPRequest()
        EQPState = eEQPState.eStop
    End Sub
    Public Sub ResetEQPState()
        EQPState = eEQPState.eRun
    End Sub
    Public Function getEQPState() As eEQPState
        Return EQPState
    End Function
        Public Sub request()
            PauseState = ePAUSESTATe.eRequest
        End Sub
    Public Function GetHomeState() As ePAUSEHomming
        Return HomePauseState
    End Function
        Public Function getState() As ePAUSESTATe
            Return PauseState
        End Function

    Public Sub paused()
        PauseState = ePAUSESTATe.ePaused
        RaiseEvent evPaused()
    End Sub

        Public Sub ResetPause()
            PauseState = ePAUSESTATe.eNotUse
        End Sub

        'Public Function isCompleted()


        'End Function

        'Private Sub trdStart()
        '    trdCheck = New Thread(AddressOf check_loop)
        '    trdCheck.Priority = ThreadPriority.Lowest
        '    trdCheck.Start()
        'End Sub

        'Private Sub check_loop()

        '    Do
        '        Thread.Sleep(500)

        '        If PauseState = ePAUSESTATe.ePaused Then
        '            Exit Do
        '        End If
        '    Loop

        'End Sub

End Class


Public Class CV7000Emergency

    Public EM_State As eEMSTATe
    '여기에 상태 저장 변수 추가 Running 또는 Standby 상태


#Region "Enum"

    Public Enum eEMSTATe
        eIDEL
        eEMERGENCY
        eResetEM
    End Enum

#End Region

    Public Sub New()
        EM_State = eEMSTATe.eIDEL
    End Sub

    Public Sub RequestReset()
        EM_State = eEMSTATe.eResetEM
    End Sub

    Public Function getState() As eEMSTATe
        Return EM_State
    End Function

    Public Sub EmergencyStop()
        EM_State = eEMSTATe.eEMERGENCY
    End Sub

    Public Sub Reset()
        EM_State = eEMSTATe.eIDEL
    End Sub

End Class


Public Class CV7000StateLamp
    '상태표시 경광등 제어용 클래스
    '경광등 상태는 아래와 같이 구분되며 S/W 제어 3번 항목 포트반 ON/OFF로 설정할 수 있음('X축 범용 출력2번을 사용)
    '1. 황색 점등 : Turn-ON  '전원 ON시 자동 점등(PLC)
    '2. 황색 점멸 : Servo-ON  '서보 온 시 자동 점멸(PLC)
    '3. 녹색 점멸 : Running(동작중) '출력
    '4. 적색 점멸 : Emergency Stop  '입력
    Public RunLampState As eLampState

    Public Enum eLampState
        eON
        eOFF
    End Enum

    Public Sub New()
        RunLampState = eLampState.eOFF
    End Sub

    Public Sub LampON()
        RunLampState = eLampState.eON
    End Sub

    Public Sub LampOFF()
        RunLampState = eLampState.eOFF
    End Sub

End Class

