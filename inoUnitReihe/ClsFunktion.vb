Public Class ClsFunktion
    Public Function Reihe(Eingabe As Long) As Long
        Dim Ergebnis As Long

        For I As Short = 1 To Eingabe
            Ergebnis += I
        Next

        Return Ergebnis
    End Function

End Class
