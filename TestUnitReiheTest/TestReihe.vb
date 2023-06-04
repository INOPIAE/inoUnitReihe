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
            Dim Ergebnis

            Ergebnis = CF.Reihe()

            Assert.AreEqual(0, Ergebnis)
            Assert.AreNotEqual(1, Ergebnis)
        End Sub

    End Class

End Namespace