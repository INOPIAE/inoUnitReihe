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


            Eingabe = 4294967295
            Vorgabe = 9223372034707292160

            Ergebnis = CF.Reihe(Eingabe)

            Assert.AreEqual(Vorgabe, Ergebnis)
        End Sub


        <Test>
        Public Sub TestReiheFehler()
            Dim Eingabe As Long

            'Eingabe zu groß
            Eingabe = 4294967296

            Dim ex = Assert.Throws(Of OverflowException)(Function() CF.Reihe(Eingabe))

            Assert.AreEqual("Die Eingabe ist größer als 4294967296 und kann nicht verarbeitet werden.", ex.Message)
        End Sub
    End Class

End Namespace