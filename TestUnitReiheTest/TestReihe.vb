Imports inoUnitReihe
Imports NUnit.Framework

Namespace TestUnitReiheTest

    Public Class TestReihe
        Dim CF As New ClsFunktion

        <SetUp>
        Public Sub Setup()
        End Sub

        <Test>
        Public Sub TestReihe()
            Dim Eingabe As Short
            Dim Vorgabe As Long
            Dim Ergebnis

            Eingabe = 4
            Vorgabe = 4

            Ergebnis = CF.Reihe(Eingabe)

            Assert.AreEqual(Vorgabe, Ergebnis)


            Eingabe = 1000
            Vorgabe = 500500

            Ergebnis = CF.Reihe(Eingabe)

            Assert.AreEqual(Vorgabe, Ergebnis)
        End Sub

    End Class

End Namespace