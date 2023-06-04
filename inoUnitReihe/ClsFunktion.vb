Public Class ClsFunktion
    Public Function Reihe(Eingabe As Short) As Short
        Dim Ergebnis As Short

        For I As Short = 1 To Eingabe
            Ergebnis += I
        Next

        Return Ergebnis
    End Function

End Class
