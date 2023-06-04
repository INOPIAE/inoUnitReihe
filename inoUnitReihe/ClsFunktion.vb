Public Class ClsFunktion
    Public Function Reihe(Eingabe As Long) As Long
        Dim Ergebnis As Long

        If Eingabe >= 4294967296 Then
            Throw New OverflowException("Die Eingabe ist größer als 4294967296 und kann nicht verarbeitet werden.")
        End If

        For I As Long = 1 To Eingabe
            Ergebnis += I
        Next

        Return Ergebnis
    End Function

End Class
