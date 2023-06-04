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
            Dim Eingabe As Long
            Dim Vorgabe As Long
            Dim Ergebnis

            Eingabe = 4
            Vorgabe = 10

            Ergebnis = CF.Reihe(Eingabe)

            Assert.AreEqual(Vorgabe, Ergebnis)


            Eingabe = 10000000000
            Vorgabe = 9223372034707292160

            Ergebnis = CF.Reihe(Eingabe)

            Assert.AreEqual(Vorgabe, Ergebnis)
        End Sub

    End Class

End Namespace