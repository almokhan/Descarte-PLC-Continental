Imports System.Windows.Forms
Imports S7.Net

Public Class Form1

    Private plc As S7.Net.Plc ' Variável para armazenar a instância do PLC
    Dim pass = 0
    Private Const rack = 0
    Private Const slot = 1
    Private Const ip = ("192.168.0.10")
    Dim codigo As String = ""
    Public timer = 0
    Dim manual = 0
    Dim fecha = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MonitorTimer.Interval = 5
        MonitorTimer.Start()

        Dim args() As String
        args = Split(Command$, " ")

        If UBound(args) >= 0 Then
            ' O conteúdo de lc_Code estará em args(0)
            codigo = args(0)
        End If


        Try

            ' Inicializar a instância do PLC
            plc = New S7.Net.Plc(CpuType.S71200, ip, rack, slot)

            ' Abrir a conexão com o PLC
            plc.Open()

            ' Verificar se a conexão foi bem-sucedida
            If plc.IsConnected Then
                WriteToPLC("M12.0", True) 'Avisa pro plc iniciar o ciclo
                Me.Show()


            Else
                MessageBox.Show("Não foi possível conectar ao PLC.")
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao conectar ao PLC: " & ex.Message)
        End Try

    End Sub


    Private Sub MonitorTimer_Tick(sender As Object, e As EventArgs) Handles MonitorTimer.Tick
        If plc IsNot Nothing AndAlso plc.IsConnected Then


            If Len(qrtextbox.Text) = Len(codigo) Then 'Verifica se deu o numero de caracteres necessarios

                If qrtextbox.Text = codigo Then
                    Me.BackColor = Color.Green
                    WriteToPLC("M2.0", True)
                    Label2.Text = ("Correto")

                Else

                    Me.BackColor = Color.Red
                    qrtextbox.Text = ""
                    Label2.Text = "Código não associado a peça"
                End If

            End If


            'apaga a text box caso o código seja maior ou menor que o esperado
            If manual = 0 Then
                If Len(qrtextbox.Text) > 0 Then
                    timer = timer + 1
                    If timer >= 400 Then
                        qrtextbox.Text = ""
                        Me.BackColor = Color.Yellow
                        Label2.Text = "Tempo esgotado, limpando caixa de texto"
                        timer = 0
                    End If
                End If
            End If
        End If
        If plc.Read("M11.0") = True Then
            WriteToPLC("M12.0", False)
            WriteToPLC("M2.0", False)
            fecha = 1
            Me.Close()

        End If

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If fecha = 0 Then
            Label2.Text = "Só é possivel fechar quando a peça for descartada"
            e.Cancel = True
        End If
    End Sub




    Private Sub WriteToPLC(address As String, value As Boolean)
        If plc IsNot Nothing AndAlso plc.IsConnected Then
            Try
                plc.Write(address, value)
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("PLC não está conectado.")
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If manual = 0 Then
            manual = 1
        Else
            manual = 0
        End If
    End Sub
End Class