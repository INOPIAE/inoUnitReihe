# inoUnitReihe

Diese Repository enthält ein VB Beispielprojekt, an dem die Erstellung einer Konsolenanwendung mit Unittests aufgezeigt wird.

Im Projekt wird das Test-Framework NUnit verwendet. 

Das Beispielprojekt wurde mit Visaul Studio 2022 geschrieben.



## Konzept von Unit-Testing

Beim Arbeiten mit Unit-Tests ist die Idee, dass jede Funktion, die im Programm aufgerufen wird, durch entsprechende Tests auf ihre Funktionalität und das erwartete Verhalten geprüft wird.

Diese Tests werden während der Entwicklung der Funktion geschrieben, bis die Funktion sich so verhält wie erwartet.

Aber auch im weiteren Verlauf der Programmentwicklung wird diese Tests wiederholt, um zu gewährleisten das die Funktionalität immer noch gegeben ist.

## Konzept Test-Driven-Development
Beim Test-Driven-Development ist der Ansatz, dass man eine Funktion in kleinen Schritten entwickelt, wobei jeder Veränderungsschritt getestet wird. Da hier aber ja nicht viele Codeänderung anstehen, sollten Fehler schnell gefunden werden.

In der Praxis hat man dabei innerhalb einer Programm-Solution zwei Projekte: das eigentliche Programm-Projekt (Programm) und eine weiters Projekt für die Test (UnitTest)

Im Idealfall geht man so vor:
1. Es wird in Unittest ein Test T geschrieben, der versucht die Methode M im Programm aufzurufen. Im Programm wird nur der Methodenrumpf, ohne Übergabeparameter und irgendeiner Logik geschrieben. Nun wird der Test ausgeführt, um zu prüfen, dass der Aufruf überhaupt funktioniert.
2. Nun wird der T so umgeschrieben, dass M mit einem Parameter aufgerufen wird. Entsprechend wird M so angepasst, dass der Parameter übergeben werden kann. Nun wird der Test ausgeführt, um zu prüfen, dass M den Parameter annimmt. Dabei wird die Rückgabe von M so einfach wie möglich gehalten.
3. T wird weiter umgeschrieben, um zu prüfen, dass der Parameter auch richtig übergeben wurde. Dazu wird M entsprechend angepasst und wieder getestet.
4. Nun wird ein erwartetes Ergebnis von M in den T vorgeben, und M so umgeschrieben, das das Ergebnis im Test verifiziert wird.
5. Nun wird T um weitere Annahmen ergänzt, um Grenzfälle zu testen.
Beispiel: Die Methode soll die Erfassung von Messwerten mit Datum speichern. Dann sollte beim Testen für die Datumseingabe nicht nur irgendein Datum getestet werden, sondern diese Fälle sollten berücksichtigt werden:
- das aktuelle Datum- die Eingabe von Null/Nothing
- ein Datum aus der Zukunft
- ein Datum aus der näheren Vergangenheit
- ein Datum aus der weiteren Vergangenheit (ein Datum aus dem letzten Jahrtausend)

## Umsetzung in der Praxis mit Visual Studio

In Visual Studio wird ein neues Projekt angelegt. (Für das Beispiel eine Konsolen-App)

Die Anwendung soll für eine Zahl alle Zahlen von 1 bis zur Vorgabe berechnenet werden: für 5 bedeutet dies: alle Werte von 1 bis 5 werden aufaddiert. 1 + 2 + 3 + 4 + 5 = 15

Jetzt wird im Projektmappen-Explorer das Kontextmenü der Projektmappe mit der rechten Maustaste geöffnet und ein weiteres Projekt über Hinzufügen erstellt. Es wird eine Testvorlage genutzt. Für das Beispiel NUnit-Test.

Es sind nun zwei Projekte im Projektmappen-Explorer zu sehen. Das Projekt der Konsolen-App (P) und das Testprojekt (T).

T wird nun der Verweis auf P hinzugefügt.

Dazu wird im Projektmappen-Explorer im Bereich T das Kontextmenu für die Abhängigkeiten geöffnet und "Projektverweis hinzufügen" genutzt.

Dort wird unter Projekte – Projektmappe P vorgeschlagen. P wird ausgewählt und hinzugefügt. Damit sind die vorbereitenden Arbeiten abgeschlossen.

Die von Visual Studio erstellte Testklasse sieht nun so aus:

``` 
Public Class TestReihe

    <SetUp>
    Public Sub Setup()
    End Sub

    <Test>
    Public Sub Test1()
        Assert.Pass()
    End Sub
End Class
```
[siehe Commit Einrichten Testprojekt](https://github.com/INOPIAE/inoUnitReihe/commit/38a2046cabab22b2c8b1ffb46ec5bdaacac9346d)

Für NUnit gilt, dass einem Test immer die Zeile <Test> vorangestellt werden muss.

Im Bereich Setup können globale Dinge vorgegeben werden, die immer bei einem Test ablaufen sollen. Mit Assert wird das Testergebnis überprüft.

Jetz wird in P eine Klasse mit der Funktion Reihe erstellt:

```
Public Class ClsFunktion
    Public Function Reihe() As Short
        Return Nothing
    End Function
End Class
```

Die Funktion ist bewusst mit Short als Rückgabewert gesetzt worden, um den Umgang mit Fehlern aufzuzeigen. (Short kann nur ganzzahlige Werte von -32,768 bis 32,767 enthalten.)

Und dazu wird ein Test geschrieben:

``` 
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
```

Mit Assert.AreEqual wird geprüft, dass der Wert von Ergebnis mit dem erwarteten Wert 0 übereinstimmt.

Mit Assert.AreNotEqual wird geprüft, dass der Wert von Ergebnis mit dem erwarteten Wert 1 nicht übereinstimmt.

Wenn eines der beiden Assert-Statements nicht erfüllt wird, wird beim Testen ein Fehler angezeigt.

Jetzt wird der Test ausgeführt.

Dazu wird der Test-Explorer geöffnet.

Im Test Explorer wird nun das grüne Dreieck zum Ausführen der Test genutzt, um den Test auszuführen.

Es sollte hier alles auf grün stehen.

[siehe Commit Einfügen des ersten Test](https://github.com/INOPIAE/inoUnitReihe/commit/5a01b2714e2f0de4d125bb6d72565cc6ef0456e0)

Als nächstes wird die Funktion um einen Parameter erweitert und geprüft, dass der Parameter auch in der Funktion ankommt:

```
Public Function Reihe(Eingabe As Short) As Short
    Return Eingabe
End Function
```

Der Test wird nun so umgeschrieben:

```
Public Sub TestReihe()
    Dim Eingabe As Short
    Dim Vorgabe As Short
    Dim Ergebnis

    Eingabe = 4
    Vorgabe = 4
    
    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)

    Eingabe = 100
    Vorgabe = 100

    Ergebnis = CF.Reihe(Eingabe)
    Assert.AreEqual(Vorgabe, Ergebnis)
End Sub
```

Der Test wird wieder im Test-Explorer ausgeführt.

Das Ergebnis sollte wieder grün sein.

[siehe Commit Erweiterung der Funktion um Parameter-Übergabe](https://github.com/INOPIAE/inoUnitReihe/commit/463e30acc24beec69998190fdbee3f814c6f2ba2)

Nun wird die eigentliche Funktionalität geschrieben.

```
Public Function Reihe(Eingabe As Short) As Short
    Dim Ergebnis As Short

    For I As Short = 1 To Eingabe
        Ergebnis += I
    Next

    Return Ergebnis
End Function
```

Und der Test wird so angepasst:

```
Public Sub TestReihe()
    Dim Eingabe As Short
    Dim Vorgabe As Long
    Dim Ergebnis

    Eingabe = 4
    Vorgabe = 10

    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)

    Eingabe = 1000
    Vorgabe = 500500

    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)
End Sub
```

Beim Testen wird nun ein Fehler ausgegeben.

Wenn im Test-Explorer der fehlerhafte (rote) Test ausgewählt wird, kann man diese Information erhalten:

```
Nachricht: 
System.OverflowException : Arithmetic operation resulted in an overflow.

Stapelüberwachung: 
ClsFunktion.Reihe(Int16 Eingabe) Zeile X
TestReihe.TestReihe() Zeile Y
```

Der Fehler resultiert daher, dass ab Eingabe von 256 das Ergebnis größer ist als 32767, welches der Maximalwert von Short ist.

Nun muss man eine Entscheidung treffen, wie man weiter vorgehen möchte.

Als erstes wird der Rückgabetyp der Funktion auf Long geändert.

```
Public FunctionReihe(Eingabe As Short) As Long
    Dim Ergebnis As Long
    For I As Short = 1 To Eingabe
        Ergebnis += I
    Next

    Return Ergebnis

End Function
```

Und der Test wiederholt. Nun sollte das Ergebnis wieder auf grün stehen.

Nun wird in der Funktion die Eingabe von Short auf Long angepasst:

```
Public Function Reihe(Eingabe As Long) As Long
    Dim Ergebnis As Long

    For I As Long = 1 To Eingabe
        Ergebnis += I
    Next

    Return Ergebnis
End Function
```

Der Test wird so angepasst:

```
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
```
[siehe Commit Änderung des Parameter auf Long](https://github.com/INOPIAE/inoUnitReihe/commit/08017914eaff4322b63ce84033109dc8ee7ee8ea)

Der Test wird wieder ausgeführt. Es gibt wieder einen Fehler:

```
Nachricht: 
System.OverflowException : Arithmetic operation resulted in an overflow.

Stapelüberwachung: 
ClsFunktion.Reihe(Int64 Eingabe) Zeile X
TestReihe.TestReihe() Zeile Y
```

Dieser Fehler kann jetzt nicht so ohne weiteres behoben werden.

Damit man eine zielführende Fehlermeldung erhält, wird die Funktion so angepasst:

```
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
```

Auf der Testseite wird ein zweiter Test für den Extremfall einfügt:

```
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
```

Es wird wieder getestet.

Es sollte wiederum alles grün sein.

[siehe Commit Einfügen der Fehlerbehandlung in Reihe](https://github.com/INOPIAE/inoUnitReihe/commit/7bb6db2a56101e8a9a1db7f86f37fca358d8a0ae)

Nun werden im Test TestReihe noch Tests für Eingaben 0, negativen Werten und Nothing eingeführt.

```
Public Sub TestReihe()
    Dim Eingabe As Long
    Dim Vorgabe As Long
    Dim Ergebnis

    'Einfache Eingabe
    Eingabe = 4
    Vorgabe = 10

    Ergebnis = CF.Reihe(Eingabe)
    Assert.AreEqual(Vorgabe, Ergebnis)

    'Eingabe größter möglicher Wert
    Eingabe = 4294967295
    Vorgabe = 9223372034707292160

    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)

    'Eingabe 0
    Eingabe = 0
    Vorgabe = 0

    Ergebnis = CF.Reihe(Eingabe)
    
    Assert.AreEqual(Vorgabe, Ergebnis)

    'Eingabe negativ
    Eingabe = -5
    Vorgabe = 0

    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)

    'Eingabe Nothing
    Eingabe = Nothing
    Vorgabe = 0

    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)

    'Eingabe großer negativer Wert
    Eingabe = -4294967296
    Vorgabe = 0

    Ergebnis = CF.Reihe(Eingabe)

    Assert.AreEqual(Vorgabe, Ergebnis)

End Sub
```

Die Tests werden wieder ausgeführt und sollten wieder alles in grün anzeigen.

[siehe Commit Weitere Tests zu Sonderfällen](https://github.com/INOPIAE/inoUnitReihe/commit/557eb78c7674af1be3c4f1d03cd58b15ef9f138b)

Mehr Sonderfälle fallen mir nicht ein.

Nun kann die Funktion in die Anwendung P implementiert werden.

Die einzelnen Schritte können über die Commit Historie nachvollzogen werden.

## Testen einer Anwendung mit einer graphischen Oberfläche

Soll eine Anwendung mit graphischer Oberfläche getestet werden, sollte die Lösung aus 3 Projekten bestehen:

- Der Anwendung mit der Graphischen Oberfläche.
- Mindestens einer Klassenbibliothek
- Mindestens einem Testprojekt

Die Anwendung sollte keine Businesslogik enthalten. Diese wird in die Klassenbiblothek(en) ausgelagert.

Die Oberfläche muss mit andern Testframeworks getestet werden.